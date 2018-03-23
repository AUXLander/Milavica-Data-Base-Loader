using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Programm
{
    const string uploads = "http://milavica/wp-content/uploads/2018/03/";
    const string wHomePage = "http://milavica-shop.ru";
    const string sStTag = "<div class=\"name\">\n            <a href=\"";
    const string path = @"C:\Users\TERMINAL\Desktop\Links";
    const string bd = @"C:\Users\TERMINAL\Desktop\bd";

    static void Main(string[] args)
    {
        GetAndSet();
        Reloads();
        Console.ReadKey();
    }
    static void Reloads()
    {
        Reload("bdAVENIJA.txt");
        Reload("bdCHARMANTE.txt");
        Reload("bdDIMANCHE LINGERIE.txt");
        Reload("bdInfinity Lingerie.txt");
        Reload("bdINNAMORE COLLANT.txt");
        Reload("bdINTRI.txt");
        Reload("bdJULIMEX.txt");
        Reload("bdLORMAR.txt");
        Reload("bdMALEMI.txt");
        Reload("bdPrimavera.txt");
        Reload("bdROSA SELVATICA.txt");
        Reload("bdROSME.txt");
        Reload("bdTribuna.txt");
        Reload("bdVOVA.txt");
        Reload("bdZETDAY.txt");
        Reload("bdАвелин.txt");
        Reload("bdМилавица.txt");
        Reload("bdПальметта - Милена.txt");
        Reload("bdЧерёмушки.txt");
        Reload("bdЭротическое белье.txt");
    }
    static void Reload(string filename)
    {
        string _path = @"C:\Users\TERMINAL\Desktop\Milavica\";
        if (File.Exists(_path + filename))
        {
            int count = File.ReadLines(_path + filename).Count();
            string wLinks = File.ReadAllText(_path + filename);
            string[] aLinks = new string[count];

            for (int i = 0; i < count; i++)
            {
                aLinks[i] = getBetweenAndDel(ref wLinks, "", "\n");
            }
            for (int i = 0; i < count; i++)
            {
                int x;
                string message = "";
                for (x = 0; (x < aLinks[i].Length) && (aLinks[i][x] != ','); x++)
                    message += aLinks[i][x];
                message += ",";
                if (x == aLinks[i].Length)
                    continue;
                int y;
                for (y = x + 1; y < aLinks[i].Length && aLinks[i][y] != ','; y++)
                {
                    if (aLinks[i][y] == ';')
                        continue;

                    if (y == x + 1)
                        message += char.ToUpper(aLinks[i][y]);
                    else
                        message += char.ToLower(aLinks[i][y]);
                }
                message += ",";
                for (x = y + 1; x < aLinks[i].Length; x++)
                    message += aLinks[i][x];

                File.AppendAllText(_path + "total.txt", message + Environment.NewLine);
            }
        }
    }
    static void GetAndSet()
    {
        GetInfo("Infinity Lingerie", getLinks("Infinity Lingerie", "/brands/infinity-lingerie/female", 3));
        GetInfo("Infinity Lingerie", getLinks("Infinity Lingerie", "/brands/infinity-lingerie/male", 2));

        GetInfo("Primavera", getLinks("Primavera", "/brands/primavera/brassiere", 1), "Бюстгальтеры");
        GetInfo("Primavera", getLinks("Primavera", "/brands/primavera/underpants", 1), "Трусы");
        GetInfo("Primavera", getLinks("Primavera", "/brands/primavera/sets", 1), "Комплекты");

        GetInfo("Tribuna", getLinks("Tribuna", "/katalog/category/view/51", 1), "Купальники");
        GetInfo("Tribuna", getLinks("Tribuna", "/katalog/category/view/60", 1), "Бюстгальтер");

        GetInfo("VOVA", getLinks("VOVA", "/katalog/category/view/50", 2), "Бюстгальтеры");
        GetInfo("VOVA", getLinks("VOVA", "/katalog/category/view/59", 1), "Трусы");

        GetInfo("Авелин", getLinks("Авелин", "/katalog/category/view/22", 3), "Бюстгальтеры");
        GetInfo("Авелин", getLinks("Авелин", "/katalog/category/view/23", 1), "Грации");
        GetInfo("Авелин", getLinks("Авелин", "/katalog/category/view/24", 2), "Трусы");


        GetInfo("Милавица", getLinks("Милавица", "/brands/milavitsa/brassiere", 10), "Бюстгальтеры");
        GetInfo("Милавица", getLinks("Милавица", "/brands/milavitsa/underpants", 3), "Трусы");
        GetInfo("Милавица", getLinks("Милавица", "/brands/milavitsa/gracie", 1), "Грации");


        GetInfo("Пальметта - Милена", getLinks("Пальметта - Милена", "/katalog/category/view/30", 2), "Бюстгальтеры");
        GetInfo("Пальметта - Милена", getLinks("Пальметта - Милена", "/katalog/category/view/32", 2), "Трусы");

        GetInfo("ROSME", getLinks("ROSME", "/katalog/category/view/41", 1), "Халаты");

        GetInfo("CHARMANTE", getLinks("CHARMANTE", "/katalog/category/view/42", 1), "Колготки");

        GetInfo("MALEMI", getLinks("MALEMI", "/katalog/category/view/43", 1), "Колготки");

        GetInfo("INNAMORE COLLANT", getLinks("INNAMORE COLLANT", "/katalog/category/view/44", 1), "Колготки");

        GetInfo("DIMANCHE LINGERIE", getLinks("DIMANCHE LINGERIE", "/brands/dimanche-lingerie", 1), "Подвязка");

        GetInfo("JULIMEX", getLinks("JULIMEX", "/brands/julimex", 1), "Разное");

        GetInfo("Черёмушки", getLinks("Черёмушки", "/katalog/category/view/54", 2), "Бюстгальтеры");

        GetInfo("INTRI", getLinks("INTRI", "/katalog/category/view/72", 1), "Корректирующее белье");
        GetInfo("INTRI", getLinks("INTRI", "/katalog/category/view/71", 1), "Трусы");
        GetInfo("INTRI", getLinks("INTRI", "/katalog/category/view/70", 5), "Трусы");

        GetInfo("AVENIJA", getLinks("AVENIJA", "/katalog/category/view/76", 1), "Корректирующее белье");
        GetInfo("AVENIJA", getLinks("AVENIJA", "/katalog/category/view/75", 1), "Бюстгальтеры");
        GetInfo("AVENIJA", getLinks("AVENIJA", "/katalog/category/view/74", 2), "Трусы");

        GetInfo("LORMAR", getLinks("LORMAR", "/katalog/category/view/78", 1), "Трусы");
        GetInfo("LORMAR", getLinks("LORMAR", "/katalog/category/view/79", 1), "Бюстгальтеры");
        GetInfo("LORMAR", getLinks("LORMAR", "/katalog/category/view/80", 1), "Разное");

        GetInfo("ROSA SELVATICA", getLinks("ROSA SELVATICA", "/katalog/category/view/82", 2), "Бюстгальтеры");
        GetInfo("ROSA SELVATICA", getLinks("ROSA SELVATICA", "/katalog/category/view/83", 1), "Трусы");

        GetInfo("ZETDAY", getLinks("ZETDAY", "/katalog/category/view/85", 2), "Бюстгальтеры, Трусы");
        GetInfo("ZETDAY", getLinks("ZETDAY", "/katalog/category/view/86", 2), "Трусы");

        GetInfo("Эротическое белье", getLinks("Эротическое белье", "/katalog/category/view/68", 2), "Эротическое белье");


    }
    static void GetInfo(string brand, int count, string type = "")
    {
        string wLinks = File.ReadAllText(path + brand + ".txt");
        WebClient wClient = new WebClient();
        string wPage;
        string[] aLinks = new string[count];

        double Progress = 0;

        for (int i = 0; i < count; i++)
        {
            aLinks[i] = getBetweenAndDel(ref wLinks, "", "\r\n");
        }
        for (int i = 0; i < count; i++)
        {
            Progress = ((i + 1) / (double)count) * 100.0;
            Console.Clear();
            Console.WriteLine("Progress: {0}%", Progress);
            if (aLinks[i].Length < 2)
                continue;

            if (aLinks[i] == "http://milavica-shop.ru\r")
                continue;

            wPage = wClient.DownloadString(aLinks[i]);
            int len;
            string name = getBetweenAndDel(ref wPage, "<h1>", "<span");
            string sku = getSKU(ref name, brand);
            name = name.Trim('\n', '\t', ' ');
            string category = "";
            string price = "";
            string sizes = "";
            string colors = "";
            string sex = "";
            string desc = "";
            string image = "";
            for (int k = 0, st = -1; k < name.Length; k++)
            {
                if (char.IsUpper(name[k]))
                {
                    if (st < 0)
                        st = k;
                    category += name[k];
                }
                else if (category.Length > 0)
                {
                    //name = name.Remove(st, k - st + 1);
                    break;
                }
            }
            len = wPage.Length + 1;
            while (len > wPage.Length)
            {
                len = wPage.Length;
                int end = wPage.IndexOf("</option>");
                int start = end - 4;
                if (end > 0)
                {
                    if (wPage[start] == '>')
                    {
                        sizes += wPage.Substring(start + 1, end - start - 1);
                        sizes += ", ";
                        wPage = wPage.Remove(start, (end + 9) - start);
                    }
                    else
                    {
                        string temp = "";
                        for (int j = 0; wPage[end - 1 - j] != '>'; j++)
                            temp += wPage[end - 1 - j];
                        temp = temp.Trim('\n', '\t', ' ');
                        if (temp != "ыретьлагтсюБ")
                        {
                            for (int j = temp.Length - 1; j >= 0; j--)
                                colors += temp[j];
                            colors += ", ";
                        }
                        wPage = wPage.Remove(end - 1 - colors.Length, colors.Length + 9);
                    }
                }
                if (price.Length == 0)
                    price = getBetweenAndDel(ref wPage, "<span id=\"block_price\">", "</span>");
                if (sex.Length == 0)
                    sex = getBetweenAndDel(ref wPage, "<span class=\"extra_fields_value\">", "</span>");
                if (desc.Length == 0)
                {
                    desc = getBetweenAndDel(ref wPage, "Описание:</p>", "</div>");
                    int _len = desc.Length + 2;
                    while (desc.Length < _len + 1)
                    {
                        _len = desc.Length;
                        desc += getBetweenAndDel(ref wPage, "<img class=\"jshop_img_thumb\" src=\"", "\"") + "\n";
                    }
                }

                if (image.Length == 0)
                {
                    image = getBetweenAndDel(ref wPage, "<a class=\"lightbox\" id=\"main_image_full", "\" >");
                    if (image.Length > 0)
                        image = image.Remove(0, image.IndexOf("http://"));
                }
            }
            int iCounter = 0;
            string sCounter = "";
            string fExt = "." + getFileExtension(image);
            while (File.Exists(@"C:\Users\TERMINAL\Desktop\images\" + sku + sCounter + fExt))
            {
                iCounter += 1;
                sCounter = "(" + iCounter.ToString() + ")";
            }
            try
            {
                wClient.DownloadFile(image, @"C:\Users\TERMINAL\Desktop\images\" + sku + sCounter + fExt);
            }
            catch (Exception e)
            {
                //File.WriteAllText(@"C:\Users\TERMINAL\Desktop\images\" + sku + sCounter + ".error", aLinks[i]);
            }
            image = uploads + sku + sCounter + fExt;
            string price_ = "";
            for (int j = 0; j < price.Length; j++)
                if (char.IsNumber(price[j]))
                    price_ += price[j];

            desc = DelCSS(desc);
            desc = desc.ToLower();
            desc = char.ToUpper(desc[0]) + desc.Remove(0, 1);
            if (colors.Length > 2)
                colors = colors.Remove(colors.Length - 2, 2);
            if (sizes.Length > 2)
                sizes = sizes.Remove(sizes.Length - 2, 2);
            if (sku.Length < 1)
                sku = sCounter;
            category = category.Trim('\n', '\t', '\r', ',');
            string line = sku + ',' + name + ",\"" + desc + "\",1," + price_ + ",\"" + brand + "," + type + "\"," + image + ",Размер,\"" + sizes + "\",Цвет,\"" + colors + "\",1,1,Пол," + sex + ",1,1";
            File.AppendAllText(bd + brand + ".txt", line + Environment.NewLine);
        }
        Console.WriteLine("Done!");
    }
    static string getSKU(ref string source, string brand = "")
    {
        string sku = "";
        int count_spaces = 0;
        for (int i = 0; i < source.Length; i++)
            if (source[i] == ' ')
                count_spaces++;
        string[] words = new string[count_spaces];

        for (int i = 0, j = 0; i < source.Length; i++)
            if (source[i] != ' ')
                words[j] += source[i];
            else j++;
        for (int i = 0; i < count_spaces; i++)
            if (words[i] == null)
                words[i] = "";
        for (int i = 0; i < count_spaces; i++)
        {
            if (hasNumber(words[i]))
            {
                if (i == 0)
                {
                    if (words[i + 1].Length <= 3)
                    {
                        sku = words[i] + words[i + 1];
                        source = source.Replace(words[i], "");
                        source = source.Replace(words[i + 1], "");
                    }
                    else
                    {
                        sku = words[i];
                        source = source.Replace(words[i], "");
                    }
                }
                else if (i < count_spaces)
                {
                    if (i == count_spaces - 1)
                    {
                        if (words[i - 1].Length <= 3 && words[i - 1].Length > 0)
                        {
                            sku = words[i] + words[i - 1];
                            source = source.Replace(words[i], "");
                            source = source.Replace(words[i - 1], "");
                        }
                        else
                        {
                            sku = words[i];
                            source = source.Replace(words[i], "");
                        }
                    }
                    else
                    {
                        if (words[i - 1].Length <= 3 && words[i - 1].Length > 0)
                        {
                            sku = words[i - 1] + words[i];
                            source = source.Replace(words[i], "");
                            source = source.Replace(words[i - 1], "");
                        }
                        else if (words[i + 1].Length <= 3 && words[i + 1].Length > 0)
                        {
                            sku = words[i] + words[i + 1];
                            source = source.Replace(words[i], "");
                            source = source.Replace(words[i + 1], "");
                        }
                        else
                        {
                            sku = words[i];
                            source = source.Replace(words[i], "");
                        }
                    }
                }
            }
        }
        if (brand.Length > 0)
            for (int i = 0; i < count_spaces; i++)
                if (CompareStrings(brand, words[i]))
                    source = source.Replace(words[i], "");
        return sku;
    }
    static bool hasNumber(string str)
    {
        if (str != null)
            for (int i = 0; i < str.Length; i++)
                if (char.IsNumber(str[i]))
                    return true;
        return false;
    }
    static int getLinks(string brand, string lnk, int count)
    {
        int n = 0;
        WebClient wClient = new WebClient();
        string wPage;
        int wPageCounter = 0;
        int len = 0;
        string filename = path + brand + ".txt";

        File.WriteAllText(filename, "");

        for (int i = 0; i < count; i++)
        {
            wPage = wClient.DownloadString(wHomePage + lnk + "?start=" + wPageCounter.ToString());
            wPageCounter += 12;
            int t = wPage.IndexOf(sStTag, 0);
            len = wPage.Length + 1;
            while (t > 0 && len > wPage.Length)
            {
                len = wPage.Length;
                string temp = wHomePage + getBetweenAndDel(ref wPage, sStTag, "\">") + Environment.NewLine;

                if (temp == "http://milavica-shop.ru\r\n")
                    continue;

                File.AppendAllText(filename, temp);
                n++;
            }
        }
        Console.WriteLine("Done!");
        return n;
    }
    static string DelCSS(string source)
    {
        string result = "";
        bool trS = false;
        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] == '<')
                trS = true;
            if (!trS)
                result += source[i];
            if (source[i] == '>')
                trS = false;
        }
        return result.Trim('\n', '\t', ' ');
    }
    static string getBetweenAndDel(ref string strSource, string strStart, string strEnd)
    {
        int Start, End;
        bool fs = strSource.Contains(strStart), ed = strSource.Contains(strEnd);
        if (fs && ed)
        {
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            string t = strSource.Substring(Start, End - Start);
            strSource = strSource.Remove(Start - strStart.Length, End - Start + strEnd.Length);
            return t;
        }
        else
        {
            return "";
        }
    }
    static string getFileExtension(string fileName)
    {
        string temp = fileName.Substring(fileName.LastIndexOf(".") + 1);
        if (temp.Length == 0)
            temp = "jpg";

        return temp;
    }
    static bool CompareStrings(string str1, string str2)
    {
        str1 = str1.ToLower();
        str2 = str2.ToLower();
        int abs = Math.Abs(str1.Length - str2.Length);
        if (abs > 1)
            return false;

        int min_length = Math.Min(str1.Length, str2.Length);

        char[] SymbolArray1 = new char[str1.Length];
        for (int i = 0; i < str1.Length; i++)
            SymbolArray1[i] = str1[i];

        char[] SymbolArray2 = new char[str2.Length];
        for (int i = 0; i < str2.Length; i++)
            SymbolArray2[i] = str2[i];

        int count_errors = 0;
        for (int i = 0; i < str1.Length; i++)
            for (int j = 0; j < str2.Length; j++)
            {
                if (SymbolArray1[i] == SymbolArray2[j])
                {
                    SymbolArray2[j] = '\0';
                    break;
                }
                if (SymbolArray2[j] != '\0')
                    count_errors++;
            }
        count_errors /= str1.Length;
        if (count_errors > 2 && abs == 1)
            return false;
        if (count_errors > 1 && abs == 0)
            return false;
        count_errors = 0;
        for (int i = 0; i < min_length - 1; i++)
            if (str1[i] != str2[i] && str1[i + 1] != str2[i + 1])
                count_errors++;
        if (count_errors > 2)
            return false;
        return true;
    }
    static string Translite(string rus)
    {
        string eng = "";
        for (int i = 0; i < rus.Length; i++)
        {

        }
        return eng;
    }
}
