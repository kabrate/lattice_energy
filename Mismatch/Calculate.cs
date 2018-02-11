using System;
class Calculate
{
    int type1, type2;//晶体类型
    double energy1, energy2;//晶体的晶格能
    public int plane1;//平面1
    public int plane2;//平面2
    public double angle, mismatch;//角度 错配度
    public Calculate(int type1, double energy1, int type2, double energy2)
    {
        this.type1 = type1;
        this.type2 = type2;
        this.energy1 = energy1;
        this.energy2 = energy2;
    }
    public double lattice_energy(int type1, double energy1, int type2, double energy2)
    {
        double sqrt2 = Math.Sqrt(2) / 2;
        double sqrt3 = Math.Sqrt(3) / 2;
        double s = 0, s1 = 0, s2 = 0, s3 = 0;
        double a = energy1, b = energy2;
        if (type1 == 1 && type2 == 1)
        {
            s1 = Math.Abs(a - b) / b;
            s2 = Math.Abs(a * sqrt2 - b) / b / 3 + Math.Abs(a * 0.98559 - Math.Sqrt(6) * b / 2) / 3 / Math.Sqrt(6) / b * 2 + Math.Abs(a - b) / 3 / b;
            s3 = Math.Abs(a * sqrt2 - b) / 3 / b + Math.Abs(a * 0.96593 - b) / 3 / b + Math.Abs(sqrt2 * a - 2 * b) / 6 / b;
            s = s1 < s2 ? s1 : s2;
            s = s < s3 ? s : s3;
            if (s1 < s2 && s1 < s3) angle = 0;
            else if (s2 < s1 && s2 < s3) angle = 9.74;
            else if (s3 < s1 && s3 < s2) angle = 15;
        }
        else if ((type1 == 1 && type2 == 2) || (type1 == 2 && type2 == 1))
        {
            s1 = Math.Abs(sqrt2 * a - b) / b / 3 + Math.Abs(a - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2) + Math.Abs(sqrt2 * a - b) / 3 / b;
            s2 = Math.Abs(a * sqrt2 - b) / b / 3 + Math.Abs(a * 0.98559 - sqrt3 * b) / 3 / sqrt3 / b + Math.Abs(0.5 * a - b) / 3 / b;
            s3 = Math.Abs(a * 0.5 - b) / 3 / b + Math.Abs(a - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2) + Math.Abs(sqrt2 * a - Math.Sqrt(6) * b) / 3 / b / Math.Sqrt(3);
            s = s1 < s2 ? s1 : s2;
            s = s < s3 ? s : s3;
            if (s1 < s2 && s1 < s3) angle = 0;
            else if (s2 < s1 && s2 < s3) angle = 9.74;
            else if (s3 < s1 && s3 < s2) angle = 15;
        }
        else if ((type1 == 2 && type2 == 3) || (type1 == 3 && type2 == 2))
        {
            s1 = Math.Abs(sqrt2 * a - b) / 3 / b + Math.Abs(a - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2) + Math.Abs(sqrt2 * a - b) / 3 / b;
            s2 = Math.Abs(a * sqrt2 - b) / b / 3 + Math.Abs(a - sqrt3 * b) / 3 / sqrt3 / b + Math.Abs(sqrt2 * a - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2);
            s3 = Math.Abs(a * sqrt2 - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2) + Math.Abs(a - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2) + Math.Abs(sqrt2 * a - Math.Sqrt(6) * b) / 3 / b / Math.Sqrt(3);
            s = s1 < s2 ? s1 : s2;
            s = s < s3 ? s : s3;
            angle = 0;
        }
        else if ((type1 == 1 && type2 == 3) || (type1 == 3 && type2 == 1))
        {
            s1 = Math.Abs(a - b) / b;
            s2 = Math.Abs(a * sqrt2 - b) / b / 3 + Math.Abs(a * 0.98559 - Math.Sqrt(6) * b / 2) / 3 / Math.Sqrt(6) / b * 2 + Math.Abs(a - b) / 3 / b;
            s3 = Math.Abs(a * sqrt2 - b) / 3 / b + Math.Abs(a * 0.96593 - b) / 3 / b + Math.Abs(sqrt2 * a - Math.Sqrt(3) * b) / 3 / b / Math.Sqrt(3);
            s = s1 < s2 ? s1 : s1;
            s = s < s3 ? s : s3;
            if (s1 < s2 && s1 < s3) angle = 0;
            else if (s2 < s1 && s2 < s3) angle = 9.74;
            else if (s3 < s1 && s3 < s2) angle = 15;
        }
        else if ((type1 == 2 && type2 == 4) || (type1 == 4 && type2 == 2))
        {
            s1 = Math.Abs(a - b) / b / 3 + Math.Abs(2 * 0.98559 * a - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2) + Math.Abs(a - b) / 3 / b;
            s2 = Math.Abs(a - b) / b / 3 + Math.Abs(2 * 0.908216 - sqrt3 * b) / 3 / b / Math.Sqrt(3) + Math.Abs(a - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2);
            s3 = Math.Abs(a - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2) + Math.Abs(2 * a * 0.8660254 - Math.Sqrt(2) * b) / 3 / b / Math.Sqrt(2) + Math.Abs(a - Math.Sqrt(6) * b) / 3 / b / Math.Sqrt(6);
            s = s1 < s2 ? s1 : s1;
            s = s < s3 ? s : s3;
            if (s1 < s2 && s1 < s3) angle = 15;
            else if (s2 < s1 && s2 < s3) angle = 24.74;
            else if (s3 < s1 && s3 < s2) angle = 30;
        }
        else if ((type1 == 1 && type2 == 4) || (type1 == 4 && type2 == 1))
        {
            s1 = Math.Abs(a - sqrt2 * b) / 3 / b / Math.Sqrt(2) + Math.Abs(2 * a * 0.965926 / Math.Sqrt(3) - b) / 3 / b + Math.Abs(a / Math.Sqrt(3) - sqrt2 * b) / 3 / b / sqrt2;
            s2 = Math.Abs(a - b) / 3 / b + Math.Abs(2 * a * 0.99578894 / Math.Sqrt(3) - Math.Sqrt(6) / 2 * b) / 3 / b / Math.Sqrt(2) * 2 + Math.Abs(1 / Math.Sqrt(3) * a - sqrt2 * b) / 3 / b / sqrt2;
            s3 = Math.Abs(a - b) / 3 / b + Math.Abs(1 / Math.Sqrt(3) * a - b) / 3 / b + Math.Abs(a / Math.Sqrt(3) - Math.Sqrt(3) * b) / 3 / b / Math.Sqrt(3);
            s = s1 < s2 ? s1 : s1;
            s = s < s3 ? s : s3;
            if (s1 < s2 && s1 < s3) angle = 15;
            else if (s2 < s1 && s2 < s3) angle = 5.26;
            else if (s3 < s1 && s3 < s2) angle = 60;
        }
        mismatch = s;
        if (s1 <= s2 && s1 <= s3) plane1 = 100;
        else if (s2 <= s1 && s2 <= s3) plane1 = 110;
        else if (s3 < s1 && s3 <= s2) plane1 = 111;
        switch (type2)
        {
            case 1: plane2 = 100; break;
            case 3: plane2 = 334; break;
            case 4: plane2 = 100; break;
        }
        return s;
    }

}