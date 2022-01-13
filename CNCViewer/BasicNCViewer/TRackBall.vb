Option Strict Off
Option Explicit On
'
Imports System.Math
'
Class TrackBall
    '
    '(c) Copyright 1993, 1994, Silicon Graphics, Inc.
    'ALL RIGHTS RESERVED
    'Permission to use, copy, modify, and distribute this software for
    'any purpose and without fee is hereby granted, provided that the above
    'copyright notice appear in all copies and that both the copyright notice
    'and this permission notice appear in supporting documentation, and that
    'the name of Silicon Graphics, Inc. not be used in advertising
    'or publicity pertaining to distribution of the software without specific,
    'written prior permission.
    '
    'THE MATERIAL EMBODIED ON THIS SOFTWARE IS PROVIDED TO YOU "AS-IS"
    'AND WITHOUT WARRANTY OF ANY KIND, EXPRESS, IMPLIED OR OTHERWISE,
    'INCLUDING WITHOUT LIMITATION, ANY WARRANTY OF MERCHANTABILITY OR
    'FITNESS FOR A PARTICULAR PURPOSE.  IN NO EVENT SHALL SILICON
    'GRAPHICS, INC.  BE LIABLE TO YOU OR ANYONE ELSE FOR ANY DIRECT,
    'SPECIAL, INCIDENTAL, INDIRECT OR CONSEQUENTIAL DAMAGES OF ANY
    'KIND, OR ANY DAMAGES WHATSOEVER, INCLUDING WITHOUT LIMITATION,
    'LOSS OF PROFIT, LOSS OF USE, SAVINGS OR REVENUE, OR THE CLAIMS OF
    'THIRD PARTIES, WHETHER OR NOT SILICON GRAPHICS, INC.  HAS BEEN
    'ADVISED OF THE POSSIBILITY OF SUCH LOSS, HOWEVER CAUSED AND ON
    'ANY THEORY OF LIABILITY, ARISING OUT OF OR IN CONNECTION WITH THE
    'POSSESSION, USE OR PERFORMANCE OF THIS SOFTWARE.
    '
    'US Government Users Restricted Rights
    'Use, duplication, or disclosure by the Government is subject to
    'restrictions set forth in FAR 52.227.19(c)(2) or subparagraph
    '(c)(1)(ii) of the Rights in Technical Data and Computer Software
    'clause at DFARS 252.227-7013 and/or in similar or successor
    'clauses in the FAR or the DOD or NASA FAR Supplement.
    'Unpublished-- rights reserved under the copyright laws of the
    'United States.  Contractor/manufacturer is Silicon Graphics,
    'Inc., 2011 N.  Shoreline Blvd., Mountain View, CA 94039-7311.
    '
    'OpenGL(TM) is a trademark of Silicon Graphics, Inc.
    '
    '
    'Trackball code:
    '
    'Implementation of a virtual trackball.
    'Implemented by Gavin Bell, lots of ideas from Thant Tessman and
    '  the August '88 issue of Siggraph's "Computer Graphics," pp. 121-129.
    '
    'Vector manip code:
    '
    'Original code from:
    'David M. Ciemiewicz, Mark Grossman, Henry Moreton, and Paul Haeberli
    '
    'Much mucking with by:
    'Gavin Bell
    '/
    '#include <math.h>
    '#include "trackball.h"
    '
    '------------------------------------------------------------------
    'Rewritten in Visual Basic .NET by Allan Worth Copyright 2010, 2011
    '------------------------------------------------------------------
    '
    '
    'This size should really be based on the distance from the center of
    'rotation to the point on the object underneath the mouse.  That
    'point would then track the mouse as closely as possible.  This is a
    'simple example, though, so that is left as an Exercise for the
    'Programmer.
    '
    Const TRACKBALLSIZE = 0.8
    Const RENORMCOUNT = 97
    'Const phiSens = +2.2              'Sets rotational sensitivity to mouse motion - this seems pretty good.
    Const phiSens = -2.2              'Sets rotational sensitivity to mouse motion - this is original value.
    'Const phiSens = +2.0              'Sets rotational sensitivity to mouse motion - this is original value.
    '
    Dim tbWidth As Integer
    Dim tbHeight As Integer
    '
    Public Sub vzero(ByRef v() As Single)
        v(0) = 0.0#
        v(1) = 0.0#
        v(2) = 0.0#
    End Sub

    Public Sub vset(ByRef v() As Single, ByVal X As Single, ByVal Y As Single, ByVal Z As Single)
        v(0) = X
        v(1) = Y
        v(2) = Z
    End Sub

    Public Sub vsub(ByRef src1() As Single, ByRef src2() As Single, ByRef dst() As Single)
        dst(0) = src1(0) - src2(0)
        dst(1) = src1(1) - src2(1)
        dst(2) = src1(2) - src2(2)
    End Sub

    Public Sub vcopy(ByRef v1() As Single, ByRef v2() As Single)
        For i As Integer = 0 To 2
            v2(i) = v1(i)
        Next i
    End Sub

    Public Sub vcross(ByRef v1() As Single, ByRef v2() As Single, ByRef cross() As Single)
        '
        Dim temp(2) As Single

        temp(0) = (v1(1) * v2(2)) - (v1(2) * v2(1))
        temp(1) = (v1(2) * v2(0)) - (v1(0) * v2(2))
        temp(2) = (v1(0) * v2(1)) - (v1(1) * v2(0))
        vcopy(temp, cross)
    End Sub

    Public Function vlength(ByRef v() As Single) As Single
        'Public Function vlength(ByVal v() As Single) As Single
        vlength = System.Math.Sqrt(v(0) * v(0) + v(1) * v(1) + v(2) * v(2))
    End Function

    Public Sub vscale(ByRef v() As Single, ByVal div As Single)
        v(0) = v(0) * div
        v(1) = v(1) * div
        v(2) = v(2) * div
    End Sub

    Public Sub vnormal(ByRef v() As Single)
        vscale(v, 1.0# / vlength(v))
    End Sub

    Public Function vdot(ByRef v1() As Single, ByRef v2() As Single) As Single
        vdot = v1(0) * v2(0) + v1(1) * v2(1) + v1(2) * v2(2)
    End Function

    Public Sub vadd(ByRef src1() As Single, ByRef src2() As Single, ByRef dst() As Single)
        dst(0) = src1(0) + src2(0)
        dst(1) = src1(1) + src2(1)
        dst(2) = src1(2) + src2(2)
    End Sub

    '
    'Ok, simulate a track-ball.  Project the points onto the virtual
    'trackball, then figure out the axis of rotation, which is the cross
    'product of P1 P2 and O P1 (O is the center of the ball, 0,0,0)
    'Note:  This is a deformed trackball-- is a trackball in the center,
    'but is deformed into a hyperbolic sheet of rotation away from the
    'center.  This particular function was chosen after trying out
    'several variations.
    '
    'It is assumed that the arguments to this routine are in the range
    '(-1.0 ... 1.0)
    '
    Public Sub tb_CalcQuat(ByVal q() As Single,
                           ByVal p1x As Single,
                           ByVal p1y As Single,
                           ByVal p2x As Single,
                           ByVal p2y As Single)
        'This routine was called "trackball_calc_quat(...)" in the TOFFSET.C (pgonoffs) demo program.
        Dim a(2) As Single '; /* Axis of rotation */
        Dim phi As Single ' /* how much to rotate about axis */
        Dim p1(2) As Single, p2(2) As Single, d(2) As Single
        Dim t As Single
        '
        If (p1x = p2x And p1y = p2y) Then
            ' Zero rotation 
            vzero(q)
            q(3) = 1.0
            Exit Sub
        End If
        '
        'First, figure out z-coordinates for projection of P1 and P2 to
        'deformed sphere
        '
        vset(p1, p1x, p1y, tb_project_to_sphere(TRACKBALLSIZE, p1x, p1y))
        vset(p2, p2x, p2y, tb_project_to_sphere(TRACKBALLSIZE, p2x, p2y))
        '
        ' Now, we want the cross product of P1 and P2
        '
        vcross(p2, p1, a)
        '
        ' Figure out how much to rotate around that axis.
        '
        vsub(p1, p2, d)
        t = vlength(d) / (2.0 * TRACKBALLSIZE)
        '
        'Avoid problems with out-of-control values...
        '
        If (t > 1.0) Then t = 1.0
        If (t < -1.0) Then t = -1.0
        phi = phiSens * System.Math.Asin(t)
        axis_to_quat(a, phi, q)
        '
    End Sub 'tb_CalcQuat

    '
    ' Given an axis and angle, compute quaternion.
    '
    Public Sub axis_to_quat(ByVal a() As Single, ByVal phi As Single, ByVal q() As Single)
        vnormal(a)
        vcopy(a, q)
        vscale(q, System.Math.Sin(phi / 2.0#))
        q(3) = System.Math.Cos(phi / 2.0#)
    End Sub

    '
    'Project an x,y pair onto a sphere of radius r OR a hyperbolic sheet
    'if we are away from the center of the sphere.
    '
    Public Function tb_project_to_sphere(ByVal r As Single, ByVal X As Single, ByVal Y As Single) As Single
        '
        Dim d As Single, t As Single, z As Single

        d = System.Math.Sqrt(X * X + Y * Y)
        '
        If (d < r * 0.707106781186548) Then     'inside sphere
            z = System.Math.Sqrt(r * r - d * d)
        Else                                    'on hyperbola
            t = r / 1.4142135623731
            z = t * t / d
        End If
        Return z

    End Function 'tb_project_to_sphere

    '
    'Given two rotations, e1 and e2, expressed as quaternion rotations,
    'figure out the equivalent single rotation and stuff it into dest.
    '
    'This routine also normalizes the result every RENORMCOUNT times it is
    'called, to keep error from creeping in.
    '
    'NOTE: This routine is written so that q1 or q2 may be the same
    'as dest (or each other).
    '
    Public Sub add_quats(ByVal q1() As Single, ByVal q2() As Single, ByVal dest() As Single)
        Static count As Integer
        count = 0
        Dim t1(3) As Single, t2(3) As Single, t3(3) As Single
        Dim tf(3) As Single

        vcopy(q1, t1)
        vscale(t1, (q2(3)))

        vcopy(q2, t2)
        vscale(t2, (q1(3)))

        vcross(q2, q1, t3)
        vadd(t1, t2, tf)
        vadd(t3, tf, tf)
        tf(3) = q1(3) * q2(3) - vdot(q1, q2)

        dest(0) = tf(0)
        dest(1) = tf(1)
        dest(2) = tf(2)
        dest(3) = tf(3)

        count += 1
        If count > RENORMCOUNT Then
            count = 0
            normalize_quat(dest)
        End If
    End Sub

    '
    'Quaternions always obey:  a^2 + b^2 + c^2 + d^2 = 1.0
    'If they don't add up to 1.0, dividing by their magnitude will
    'renormalize them.
    '
    'Note: See the following for more information on quaternions:
    '
    '- Shoemake, K., Animating rotation with quaternion curves, Computer
    '  Graphics 19, No 3 (Proc. SIGGRAPH'85), 245-254, 1985.
    '- Pletinckx, D., Quaternion calculus as a basic tool in computer
    '  graphics, The Visual Computer 5, 2-13, 1989.
    '
    Public Sub normalize_quat(ByVal q() As Single)
        Dim i As Integer
        Dim mag As Single

        mag = System.Math.Sqrt(q(0) * q(0) + q(1) * q(1) + q(2) * q(2) + q(3) * q(3))
        For i = 0 To 3
            q(i) = q(i) / mag
        Next i
    End Sub

    '
    'Build a rotation matrix, given a quaternion rotation.
    '
    Public Sub build_rotmatrix(ByRef m() As Single, ByVal q() As Single)
        m(0) = 1.0 - 2.0 * (q(1) * q(1) + q(2) * q(2))    ' Xx m[0][0] originally in trackbal.c
        m(1) = 2.0 * (q(0) * q(1) - q(2) * q(3))          ' Xy m[0][1]
        m(2) = 2.0 * (q(2) * q(0) + q(1) * q(3))          ' Xz m[0][2]
        m(3) = 0.0                                        ' Xw m[0][3]

        m(4) = 2.0 * (q(0) * q(1) + q(2) * q(3))          ' Yx m[1][0]
        m(5) = 1.0 - 2.0 * (q(2) * q(2) + q(0) * q(0))    ' Yy m[1][1]
        m(6) = 2.0 * (q(1) * q(2) - q(0) * q(3))          ' Yz m[1][2]
        m(7) = 0.0                                        ' Yw m[1][3]

        m(8) = 2.0 * (q(2) * q(0) - q(1) * q(3))          ' Zx m[2][0]
        m(9) = 2.0 * (q(1) * q(2) + q(0) * q(3))          ' Zy m[2][1]
        m(10) = 1.0 - 2.0 * (q(1) * q(1) + q(0) * q(0))   ' Zz m[2][2]
        m(11) = 0.0                                       ' Zw m[2][3]

        m(12) = 0.0                                       ' Tx m[3][0]
        m(13) = 0.0                                       ' Ty m[3][1]
        m(14) = 0.0                                       ' Tz m[3][2]
        m(15) = 1.0                                       ' Tw m[3][3]
    End Sub

End Class 'Trkball

