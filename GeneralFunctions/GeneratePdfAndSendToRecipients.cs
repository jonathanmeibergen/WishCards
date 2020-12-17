using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;

namespace WishCards.GeneralFunctions
{
    public class GeneratePdfAndSendToRecipients
    {
        #region generateandsendpdf
        public static void GenerateAndSendData(ViewModel.SenderAndRecieversOnePersonSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {  
                var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(),model.sender.firstname, model.sender.lastname, contenttext, background, song, font);
                //<summary>
                // commented out, to test pdf generation without sending file
                //<summary>
                //SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email,stringpath);
        }

        public static void GenerateAndSendData(ViewModel.SenderAndRecieversTwoPersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {
            var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, contenttext, background, song, font);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient2.Email, stringpath, song);

        }

        public static void GenerateAndSendData(ViewModel.SenderAndRecieversThreePersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {
            var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, contenttext, background, song, font);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient2.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient3.Email, stringpath, song);

        }

        public static void GenerateAndSendData(ViewModel.SenderAndRecieversFourPersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {
            var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, contenttext, background, song, font);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient2.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient3.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient4.Email, stringpath, song);

        }

        public static void GenerateAndSendData(ViewModel.SenderAndRecieverFivePersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {
            var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, contenttext, background, song, font);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient2.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient3.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient4.Email, stringpath, song);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient5.Email, stringpath, song);
        }

        public static void GenerateAndSendData(ViewModel.SenderAndRecieverOnePersonMultipleChoice model)
        {
            var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(),model.sender.firstname,model.sender.lastname, model.sender.messagetoshow, model.Recipient1.StoreBackgroundImage, model.Recipient1.StoreMp3, model.Recipient1.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email, stringpath, model.Recipient1.StoreMp3);

        }

        public static void GenerateAndSendData(ViewModel.SenderAndRecieverTwoPersonsMultipleChoice model)
        {
            var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient1.StoreBackgroundImage, model.Recipient1.StoreMp3, model.Recipient1.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email, stringpath, model.Recipient1.StoreMp3);
            var stringpath2 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient2.StoreBackgroundImage, model.Recipient2.StoreMp3, model.Recipient2.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient2.Email, stringpath, model.Recipient2.StoreMp3);

        }

        public static void GenerateAndSendData(ViewModel.SenderAndRecieverThreePersonsMultipleChoice model)
        {
            var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient1.StoreBackgroundImage, model.Recipient1.StoreMp3, model.Recipient1.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email, stringpath, model.Recipient1.StoreMp3);
            var stringpath2 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient2.StoreBackgroundImage, model.Recipient2.StoreMp3, model.Recipient2.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient2.Email, stringpath, model.Recipient2.StoreMp3);
            var stringpath3 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient3.StoreBackgroundImage, model.Recipient3.StoreMp3, model.Recipient3.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient3.Email, stringpath, model.Recipient3.StoreMp3);

        }

        public static void GenerateAndSendData(ViewModel.SenderAndRecieverFourPersonsMultipleChoice model)
        {
            var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient1.StoreBackgroundImage, model.Recipient1.StoreMp3, model.Recipient1.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email, stringpath, model.Recipient1.StoreMp3);
            var stringpath2 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient2.StoreBackgroundImage, model.Recipient2.StoreMp3, model.Recipient2.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient2.Email, stringpath, model.Recipient2.StoreMp3);
            var stringpath3 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient3.StoreBackgroundImage, model.Recipient3.StoreMp3, model.Recipient3.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient3.Email, stringpath, model.Recipient3.StoreMp3);
            var stringpath4 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient4.StoreBackgroundImage, model.Recipient4.StoreMp3, model.Recipient4.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient4.Email, stringpath, model.Recipient4.StoreMp3);

        }

        public static void GenerateAndSendData(ViewModel.SenderAndRecieverFivePersonsMultipleChoice model)
        {
            var stringpath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient1.StoreBackgroundImage, model.Recipient1.StoreMp3, model.Recipient1.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient1.Email, stringpath, model.Recipient1.StoreMp3);
            var stringpath2 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient2.StoreBackgroundImage, model.Recipient2.StoreMp3, model.Recipient2.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient2.Email, stringpath, model.Recipient2.StoreMp3);
            var stringpath3 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient3.StoreBackgroundImage, model.Recipient3.StoreMp3, model.Recipient3.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient3.Email, stringpath, model.Recipient3.StoreMp3);
            var stringpath4 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient4.StoreBackgroundImage, model.Recipient4.StoreMp3, model.Recipient4.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient4.Email, stringpath, model.Recipient4.StoreMp3);
            var stringpath5 = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(ReturnPathString.ReturnUniqueFileName(), model.sender.firstname, model.sender.lastname, model.sender.messagetoshow, model.Recipient5.StoreBackgroundImage, model.Recipient5.StoreMp3, model.Recipient5.StoreFont);
            SmtpMailService.SendCustomerMail.SendMailToCustomer(model.Recipient5.Email, stringpath, model.Recipient5.StoreMp3);
        }

        #endregion

    }
}
