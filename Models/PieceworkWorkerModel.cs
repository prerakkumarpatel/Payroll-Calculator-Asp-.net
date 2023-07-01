/* PieceworkWorker model for WebApp
 * Author: Preakkumar Patel
 * Created: November 16, 2022
 * Updated: November 29, 2022
 * Description:
 * This is a class representing individual pieceworkworker objects.
 */
using System.ComponentModel.DataAnnotations;

namespace Payroll_Calculator.Models
{
    public class PieceworkWorkerModel
    {
        #region Variables
        /// <summary>
        /// Pay ranges Pay
        /// </summary>
        ///
        private static double Pay0, Pay1, Pay2, Pay3, Pay4, Pay5;
        private static double Bonus = 200.0;


        //static variables for summary data
        internal static int totalWorkers = 0;
        internal static int totalMessage = 0;
        internal static double totalPay = 0.0;

        //Some constants
        public const int MinimumMessage = 1;
        public const int MaximumMessage = 1000000;
        #endregion
        #region Properties

        /// <summary>
        /// Id for identity to the worker
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// To Add Worker Entry Date
        /// </summary>
        public DateTime EntryDate { get; set; } = DateTime.Now;


        /// <summary>
        /// first Name of worker
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a First Name.")]
        [MinLength(2, ErrorMessage = "First Name must be at least {1} characters long.")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [Display(Name = " First Name")]
        public string FirstName { get; set; } = String.Empty;



        /// <summary>
        ///last Name of worker
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a  Last   Name.")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [MinLength(2, ErrorMessage = "Last Name must be at least {1} characters long.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = String.Empty;


        /// <summary>
        /// Message Entry
        /// </summary>
        [Range(MinimumMessage, MaximumMessage, ErrorMessage = "Number of message must be in between {1} and {2}.")]
        [Display(Name = "Number of Messages:")]
        public int Message { get; set; }

        /// <summary>
        /// Pay 
        /// </summary>
        [Display(Name = "Workers Calculated Pay:")]
        [DisplayFormat(DataFormatString = "c")]
        public double Pay { get; protected set; }


        /// <summary>
        /// to check Seniority
        /// </summary>
        public bool IsSenior { get; set; } = false;


        /// <summary>
        /// validate Pay and check for Senior and alter range Pay Accordingly
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        protected internal virtual double GetPay()
        {
            if (IsSenior)
            {
                Pay0 = 0.0;
                Pay1 = 0.018;
                Pay2 = 0.021;
                Pay3 = 0.024;
                Pay4 = 0.027;
                Pay5 = 0.03;
            }
            else
            {
                Pay0 = 0.0;
                Pay1 = 0.025;
                Pay2 = 0.03;
                Pay3 = 0.035;
                Pay4 = 0.040;
                Pay5 = 0.046;
            }

            if (Message == 0)
            {
                Pay = Pay0;
            }
            else if (Message >= 1 && Message <= 1249)
            {
                Pay = Pay1;
            }

            else if (Message >= 1250 && Message <= 2499)
            {
                Pay = Pay2;
            }

            else if (Message >= 2500 && Message <= 3749)
            {
                Pay = Pay3;
            }

            else if (Message >= 3750 && Message <= 4999)
            {
                Pay = Pay4;
            }

            else if (Message >= 5000)
            {
                Pay = Pay5;
            }


            totalWorkers++;
            Pay = Math.Round(Message * Pay, 2, MidpointRounding.AwayFromZero);

            //For senior worker adds bonus
            if (IsSenior)
                Pay = Pay + Bonus;

            totalPay += Pay;
            totalMessage += Message;
            return Pay;
        }
        #endregion
        
    }

}
