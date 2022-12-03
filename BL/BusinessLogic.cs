using CoronaManagment.DAL;
using CoronaManagment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CoronaManagment.BL
{
    public class BusinessLogic
    {
        public static List<Insured> GetInsurees() 
        {
            var table = DataAccess.GetInsurees();
            List<Insured> insurees = null;
            if (table.Rows.Count > 0) 
            {
                insurees = new List<Insured>();
                foreach (DataRow row in table.Rows)
                {
                    string encryptedId = EncryptionUtils.Encrypt(row["ID"].ToString());
                    insurees.Add(new Insured
                    {
                        Id = encryptedId,
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                    }); ;
                }
            }

            return insurees;
        }

        private static List<Vacine> GetInsuredVacineList(string insuredID) {
            var vacinesList = new List<Vacine>();
            var table = DataAccess.getInsuredInform(insuredID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["TypeSickOrVacciene"].ToString() == "1")
                    {
                        var VacineInfo = (new Vacine
                        {
                            InsuredID = row["InsuredID"].ToString(),
                            Company = row["company"].ToString(),
                            Number = row["number"].ToString(),
                            ReceivingDate = row["VaccineDate"].ToString()

                        });
                        vacinesList.Add(VacineInfo);
                    }
                   
                }
            }
            return vacinesList;
        }

        public static Insured getInsuredInform(string insuredID)
        {
            var table = DataAccess.getInsuredInformByID(EncryptionUtils.Decrypt(insuredID));
            Insured insureesInfo = null;
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    string encryptedId = EncryptionUtils.Encrypt(row["ID"].ToString());
                    insureesInfo = (new Insured
                    {
                        Id = encryptedId,
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        InsuredID = row["TZ"].ToString(),
                        Addres = row["Addres"].ToString(),
                        BirthDate = row["BirthDate"].ToString(),
                        Tel = row["Tel"].ToString(),
                        Phone = row["Phone"].ToString(),
                    });
                    insureesInfo.VacinesList = new List<Vacine>();
                }
            }

            table = DataAccess.getInsuredInform(EncryptionUtils.Decrypt(insuredID));
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["TypeSickOrVacciene"].ToString() == "1")
                    {
                        var VacineInfo = (new Vacine
                        {
                            InsuredID = row["InsuredID"].ToString(),
                            Company = row["company"].ToString(),
                            Number = row["number"].ToString(),
                            ReceivingDate = row["VaccineDate"].ToString()

                        });
                        insureesInfo.VacinesList.Add(VacineInfo);
                    }
                    else
                    {
                        insureesInfo.disease = (new Disease
                        {
                            InsuredID = row["InsuredID"].ToString(),
                            StartingDate = row["VaccineDate"].ToString(),
                            RecoveringDate = row["ReturnDate"].ToString(),
                        });
                    }
                }
            }
            return insureesInfo;
        }
        public static void Delete(string Id) 
        {
            string DecryptedId = EncryptionUtils.Decrypt(Id);
            DataAccess.Delete(DecryptedId);
        }

        public static void AddInsured(Insured insured)
        {
            DataAccess.Add(insured);
        }

        private static void ValidateVacine(Vacine vacine) 
        {
            if (!DateTime.TryParse(vacine.ReceivingDate, out DateTime td))
            {
                throw new Exception("נא להזין תאריך חוקי עבור החיסון");
            }
        }
        public static void AddVacine(Vacine vacine)
        {
            ValidateVacine(vacine);
            vacine.InsuredID = EncryptionUtils.Decrypt(vacine.InsuredID);
            DataAccess.AddVacine(vacine);
        }
        public static List<Vacine> getVacineByInsuredId(string InsuredID)
        {
            return GetInsuredVacineList(InsuredID);
        }
        public static void UpdateInsured(Insured insured)
        {
            insured.Id = EncryptionUtils.Decrypt(insured.Id);
            DataAccess.UpdateInsured(insured);
        }
    }
}