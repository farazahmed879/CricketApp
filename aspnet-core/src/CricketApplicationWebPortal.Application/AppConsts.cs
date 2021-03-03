namespace CricketApplicationWebPortal
{
    public class AppConsts
    {
        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public const string DefaultPassPhrase = "gsKxGZ012HLL3MI5";

        public const string SuccessfullyInserted = "Record Successfully Inserted";
        public const string SuccessfullyUpdated = "Record Successfully Updated";
        public const string SuccessfullyDeleted = "Record Successfully Deleted";
        public const string InsertFailure = "Record Failed To Insert";
        public const string UpdateFailure = "Record Failed To Update";
        public const string DeleteFailure = "Record Failed To Delete";

        //Booking Statuses Constants
        public const string Available = "Available";
        public const string Confirmed = "Confirmed";
        public const string Apply = "Apply";

        //DateType
        public const string ThisWeek = "ThisWeek";
        public const string ThisMonth = "ThisMonth";
        public const string ThisYear = "ThisYear";
        public const string AllYear = "AllYear";
    }
}
