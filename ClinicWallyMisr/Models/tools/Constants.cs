using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    public class Constants
    {
        //TODO all select options here  
        
        private static string FolderPath = AppDomain.CurrentDomain.BaseDirectory;
        public static Dictionary<string, string> gender;
        public static Dictionary<string, string> religion;
        public static Dictionary<string, string> ScientificDegree;
        public static Dictionary<string, string> MedicineType;
        public static Dictionary<string, string> Dose;
        public static Dictionary<string, string> masterStatus;
        public static Dictionary<string, string> site;
        public static Dictionary<string, string> firstStatus;
        public static Dictionary<string, string> education;
        public static Dictionary<string, string> nationality;
        public static Dictionary<string, string> maritalStatus;
        public static Dictionary<string, string> referredFrom;
        public static Dictionary<string, string> governorate;
        public static Dictionary<string, string> relation;
        public static Dictionary<string, string> demographicPationtIs;
        public static Dictionary<string, string> demographicType;
        public static Dictionary<string, string> menstrual;
        public static Dictionary<string, string> contraception;

        static Constants()
        {
            gender = readConstantFile("gender");
            religion = readConstantFile("religion");
            ScientificDegree = readConstantFile("ScientificDegree");
            MedicineType = readConstantFile("MedicineType");
            Dose = readConstantFile("Dose");
            masterStatus = readConstantFile("masterStatus");
            site = readConstantFile("site");
            firstStatus = readConstantFile("firstStatus");
            education = readConstantFile("education");
            nationality = readConstantFile("nationality");
            maritalStatus = readConstantFile("maritalStatus");
            referredFrom = readConstantFile("referredFrom");
            governorate = readConstantFile("governorate");
            relation = readConstantFile("relation");
            demographicPationtIs = readConstantFile("demographicPationtIs");
            demographicType = readConstantFile("demographicType");
            menstrual = readConstantFile("menstrual");
            contraception = readConstantFile("contraception");

        }
        internal static void remove(string constant, string value)
        {
            switch (constant)
            {
                case "gender":
                    if (Constants.gender.ContainsKey(value))
                    {
                        Constants.gender.Remove(value);
                        EditConstantFile(gender, "gender");
                    }
                    break;
                case "religion":
                    if (Constants.religion.ContainsKey(value))
                    {
                        Constants.religion.Remove(value);
                        EditConstantFile(religion, "religion");
                    }
                    break;
                case "ScientificDegree":
                    if (Constants.ScientificDegree.ContainsKey(value))
                    {
                        Constants.ScientificDegree.Remove(value);
                        EditConstantFile(ScientificDegree, "ScientificDegree");
                    }
                    break;
                case "MedicineType":
                    if (Constants.MedicineType.ContainsKey(value))
                    {
                        Constants.MedicineType.Remove(value);
                        EditConstantFile(MedicineType, "MedicineType");
                    }
                    break;
                case "Dose":
                    if (Constants.Dose.ContainsKey(value))
                    {
                        Constants.Dose.Remove(value);
                        EditConstantFile(Dose, "Dose");
                    }
                    break;
                case "masterStatus":
                    if (Constants.masterStatus.ContainsKey(value))
                    {
                        Constants.masterStatus.Remove(value);
                        EditConstantFile(masterStatus, "masterStatus");
                    }
                    break;
                case "site":
                    if (Constants.site.ContainsKey(value))
                    {
                        Constants.site.Remove(value);
                        EditConstantFile(site, "site");
                    }
                    break;
                case "firstStatus":
                    if (Constants.firstStatus.ContainsKey(value))
                    {
                        Constants.firstStatus.Remove(value);
                        EditConstantFile(firstStatus, "firstStatus");
                    }
                    break;
                case "education":
                    if (Constants.education.ContainsKey(value))
                    {
                        Constants.education.Remove(value);
                        EditConstantFile(education, "education");
                    }
                    break;
                case "nationality":
                    if (Constants.nationality.ContainsKey(value))
                    {
                        Constants.nationality.Remove(value);
                        EditConstantFile(nationality, "nationality");
                    }
                    break;
                case "maritalStatus":
                    if (Constants.maritalStatus.ContainsKey(value))
                    {
                        Constants.maritalStatus.Remove(value);
                        EditConstantFile(maritalStatus, "maritalStatus");
                    }
                    break;
                case "referredFrom":
                    if (Constants.referredFrom.ContainsKey(value))
                    {
                        Constants.referredFrom.Remove(value);
                        EditConstantFile(referredFrom, "referredFrom");
                    }
                    break;
                case "governorate":
                    if (Constants.governorate.ContainsKey(value))
                    {
                        Constants.governorate.Remove(value);
                        EditConstantFile(governorate, "governorate");
                    }
                    break;
                case "relation":
                    if (Constants.relation.ContainsKey(value))
                    {
                        Constants.relation.Remove(value);
                        EditConstantFile(relation, "relation");
                    }
                    break;
                case "demographicPationtIs":
                    if (Constants.demographicPationtIs.ContainsKey(value))
                    {
                        Constants.demographicPationtIs.Remove(value);
                        EditConstantFile(demographicPationtIs, "demographicPationtIs");
                    }
                    break;
                case "demographicType":
                    if (Constants.demographicType.ContainsKey(value))
                    {
                        Constants.demographicType.Remove(value);
                        EditConstantFile(demographicType, "demographicType");
                    }
                    break;
                case "menstrual":
                    if (Constants.menstrual.ContainsKey(value))
                    {
                        Constants.menstrual.Remove(value);
                        EditConstantFile(menstrual, "menstrual");
                    }
                    break;
                case "contraception":
                    if (Constants.contraception.ContainsKey(value))
                    {
                        Constants.contraception.Remove(value);
                        EditConstantFile(contraception, "contraception");
                    }
                    break;
                default:
                    break;
            }
        }

        public static void add(string constant, string value)
        {
            switch (constant)
            {
                case "gender":
                    if (!Constants.gender.ContainsKey(value))
                    {
                        Constants.gender.Add(value , value);
                        EditConstantFile(gender, "gender");
                    }
                    break;
                case "religion":
                    if (!Constants.religion.ContainsKey(value))
                    {
                        Constants.religion.Add(value, value);
                        EditConstantFile(religion, "religion");
                    }
                    break;
                case "ScientificDegree":
                    if (!Constants.ScientificDegree.ContainsKey(value))
                    {
                        Constants.ScientificDegree.Add(value, value);
                        EditConstantFile(ScientificDegree, "ScientificDegree");
                    }
                    break;
                case "MedicineType":
                    if (!Constants.MedicineType.ContainsKey(value))
                    {
                        Constants.MedicineType.Add(value, value);
                        EditConstantFile(MedicineType, "MedicineType");
                    }
                    break;
                case "Dose":
                    if (!Constants.Dose.ContainsKey(value))
                    {
                        Constants.Dose.Add(value, value);
                        EditConstantFile(Dose, "Dose");
                    }
                    break;
                case "masterStatus":
                    if (!Constants.masterStatus.ContainsKey(value))
                    {
                        Constants.masterStatus.Add(value, value);
                        EditConstantFile(masterStatus, "masterStatus");
                    }
                    break;
                case "site":
                    if (!Constants.site.ContainsKey(value))
                    {
                        Constants.site.Add(value, value);
                        EditConstantFile(site, "site");
                    }
                    break;
                case "firstStatus":
                    if (!Constants.firstStatus.ContainsKey(value))
                    {
                        Constants.firstStatus.Add(value, value);
                        EditConstantFile(firstStatus, "firstStatus");
                    }
                    break;
                case "education":
                    if (!Constants.education.ContainsKey(value))
                    {
                        Constants.education.Add(value, value);
                        EditConstantFile(education, "education");
                    }
                    break;
                case "nationality":
                    if (!Constants.nationality.ContainsKey(value))
                    {
                        Constants.nationality.Add(value, value);
                        EditConstantFile(nationality, "nationality");
                    }
                    break;
                case "maritalStatus":
                    if (!Constants.maritalStatus.ContainsKey(value))
                    {
                        Constants.maritalStatus.Add(value, value);
                        EditConstantFile(maritalStatus, "maritalStatus");
                    }
                    break;
                case "referredFrom":
                    if (!Constants.referredFrom.ContainsKey(value))
                    {
                        Constants.referredFrom.Add(value, value);
                        EditConstantFile(referredFrom, "referredFrom");
                    }
                    break;
                case "governorate":
                    if (!Constants.governorate.ContainsKey(value))
                    {
                        Constants.governorate.Add(value, value);
                        EditConstantFile(governorate, "governorate");
                    }
                    break;
                case "relation":
                    if (!Constants.relation.ContainsKey(value))
                    {
                        Constants.relation.Add(value, value);
                        EditConstantFile(relation, "relation");
                    }
                    break;
                case "demographicPationtIs":
                    if (!Constants.demographicPationtIs.ContainsKey(value))
                    {
                        Constants.demographicPationtIs.Add(value, value);
                        EditConstantFile(demographicPationtIs, "demographicPationtIs");
                    }
                    break;
                case "demographicType":
                    if (!Constants.demographicType.ContainsKey(value))
                    {
                        Constants.demographicType.Add(value, value);
                        EditConstantFile(demographicType, "demographicType");
                    }
                    break;
                case "menstrual":
                    if (!Constants.menstrual.ContainsKey(value))
                    {
                        Constants.menstrual.Add(value, value);
                        EditConstantFile(menstrual, "menstrual");
                    }
                    break;
                case "contraception":
                    if (!Constants.contraception.ContainsKey(value))
                    {
                        Constants.contraception.Add(value, value);
                        EditConstantFile(contraception, "contraception");
                    }
                    break;
                default:
                    break;
            }
        }


        private static void EditConstantFile(Dictionary<string, string> constant , string constantName)
        {
            List<string>lines = new List<string>();
            foreach (var item in constant)
	{
                lines.Add(item.Key+":"+item.Value);
	}
            File.WriteAllLines(FolderPath + constantName + ".txt", lines);
            
        }
        private static Dictionary<string, string> readConstantFile(string constant)
        {
            Dictionary<string, string> constDic = new Dictionary<string, string>();
           string[] lines = File.ReadAllLines(FolderPath + constant + ".txt");
           foreach (var item in lines)
           {
               constDic.Add(item.Split(':')[0] , item.Split(':')[1]);
           }
           return constDic;
        }

    }
}