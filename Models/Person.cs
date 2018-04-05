
    public class Person
    {
         public string PersonID;
         public string PersonLastName;
         public string PersonFirstName;
         public DateTime PersonBirthDate;
         public string PersonEmail;
   

        public int SavePerson()
        {
            string sql = "INSERT people VALUES(@PersonLastName, @PersonFirstName, @PersonBirthDate, @PersonEmail)";

            //SqlParameter paramPersonID = new SqlParameter("@PersonID", PersonID);
            SqlParameter paramPersonLastName = new SqlParameter("@PersonLastName", PersonLastName);
            SqlParameter paramPersonFirstName = new SqlParameter("@PersonFirstName", PersonFirstName);
            SqlParameter paramPersonBirthDate = new SqlParameter("@PersonBirthDate", PersonBirthDate);
            SqlParameter paramPersonEmail = new SqlParameter("@PersonEmail", PersonEmail);

            SqlParameter[] myparameters = new SqlParameter[4];
            myparameters[0] = paramPersonLastName;
            myparameters[1] = paramPersonFirstName;
            myparameters[2] = paramPersonBirthDate;
            myparameters[3] = paramPersonEmail;

           // SqlParameter[] myParameters2 = new SqlParameter[2];

            DBUtil.Exec(sql, myparameters);

            return 0;
        }
    }
}