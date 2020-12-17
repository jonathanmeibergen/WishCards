using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;
using WishCards.Models;
using WishCards.Extensions;
using System.ComponentModel;
using WishCards.Attributes;
using WishCards.DAL;
using WishCards.Enumerations;
using WishCards.Interfaces;
using WishCards.ViewModel;

namespace WishCards.Controllers
{
    public class FillInDataController : Controller
    {
        #region FillInFormAndSendData
        // GET: FillInDataController
        private IdataService _dataService = MockDataService.GetMockDataService();
        public ActionResult FillInData()
        public async Task<IActionResult> Index()
        {
            SenderAndRecieversOnePersonSingleChoice item = new SenderAndRecieversOnePersonSingleChoice();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            item.GeneralMp3Choice = new Enumerations.Mp3Enum();
            item.GeneralFontChoice = new Enumerations.FontsEnum();
            item.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
            return View(item);
        }

        // POST: FillInDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInData(SenderAndRecieversOnePersonSingleChoice item)
        {
            //try
            //{
            //    _dataService.AddRecipient(item.Recipient1);
            //    _dataService.AddSender(item.sender);
            //    var item2 = new Models.WishCard()
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Recipients = item.Recipient1,
            //        sender = item.sender,
            //        Text = item.sender.messagetoshow,
            //        font = item.GeneralFontChoice,
            //        background = item.GeneralBackgroundImageChoice,
            //        mp3 = item.GeneralMp3Choice

            //    };
            //    _dataService.AddWishCard(item2);

            //<summary>
            // working code commented out by pdf file generation testing code
            //<summary>

            string contenttext = "yes";
            var enum1 = BackgroundImageEnum.Background1;
            var enum2 = FontsEnum.Courier;
            var enum3 = Mp3Enum.Jingle1;
            string storepath = ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer(GeneralFunctions.ReturnPathString.ReturnUniqueFileName(), "john", "smith", contenttext, enum1, enum3, enum2);
            ViewBag.pathmessage = "this";
            //GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item, item.sender.messagetoshow, item.GeneralBackgroundImageChoice, item.GeneralMp3Choice, item.GeneralFontChoice);
                return RedirectToAction("EndScreen", "EndScreen");
//            }
//#pragma warning disable CS0168 // Variable is declared but never used
//            catch (NullReferenceException ex)
//#pragma warning restore CS0168 // Variable is declared but never used
//            {
//                SenderAndRecieversOnePersonSingleChoice item2 = new SenderAndRecieversOnePersonSingleChoice();
//                item2.sender = new Models.SenderData();
//                item2.Recipient1 = new Models.Recipient();
//                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
//                item2.GeneralFontChoice = new Enumerations.FontsEnum();
//                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
//                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
//                return View(item2);
//            }
//#pragma warning disable CS0168 // Variable is declared but never used
//            catch (ArgumentNullException ex)
//#pragma warning restore CS0168 // Variable is declared but never used
//            {
//                SenderAndRecieversOnePersonSingleChoice item2 = new SenderAndRecieversOnePersonSingleChoice();
//                item2.sender = new Models.SenderData();
//                item2.Recipient1 = new Models.Recipient();
//                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
//                item2.GeneralFontChoice = new Enumerations.FontsEnum();
//                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
//                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
//                return View(item2);
//            }
//#pragma warning disable CS0168 // Variable is declared but never used
//            catch (Exception ex)
//#pragma warning restore CS0168 // Variable is declared but never used
//            {
//                SenderAndRecieversOnePersonSingleChoice item2 = new SenderAndRecieversOnePersonSingleChoice();
//                item2.sender = new Models.SenderData();
//                item2.Recipient1 = new Models.Recipient();
//                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
//                item2.GeneralFontChoice = new Enumerations.FontsEnum();
//                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
//                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
//                return View(item2);
//            }

        }

        public ActionResult FillInDataTwoPersonsSingleChoice()
        {
            SenderAndRecieversTwoPersonsSingleChoice item = new SenderAndRecieversTwoPersonsSingleChoice();
            item.Recipient2 = new Models.Recipient();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            item.GeneralMp3Choice = new Enumerations.Mp3Enum();
            item.GeneralFontChoice = new Enumerations.FontsEnum();
            item.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInDataTwoPersonsSingleChoice(SenderAndRecieversTwoPersonsSingleChoice item)
        {
            try
            {
                _dataService.AddRecipient(item.Recipient1);
                _dataService.AddRecipient(item.Recipient2);
                _dataService.AddSender(item.sender);
                var item2 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient1,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item3 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient2,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                }; 
                _dataService.AddWishCard(item2);
                _dataService.AddWishCard(item3);
                GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item, item.sender.messagetoshow, item.GeneralBackgroundImageChoice, item.GeneralMp3Choice, item.GeneralFontChoice);
                return RedirectToAction("EndScreen", "EndScreen");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieversTwoPersonsSingleChoice item2 = new SenderAndRecieversTwoPersonsSingleChoice();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentNullException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieversTwoPersonsSingleChoice item2 = new SenderAndRecieversTwoPersonsSingleChoice();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieversTwoPersonsSingleChoice item2 = new SenderAndRecieversTwoPersonsSingleChoice();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
                return View(item2);
            }
        }

        public ActionResult FillInDataThreePersonsSingleChoice()
        {
            SenderAndRecieversThreePersonsSingleChoice item = new SenderAndRecieversThreePersonsSingleChoice();
            item.Recipient3 = new Models.Recipient();
            item.Recipient2 = new Models.Recipient();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            item.GeneralMp3Choice = new Enumerations.Mp3Enum();
            item.GeneralFontChoice = new Enumerations.FontsEnum();
            item.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInDataThreePersonsSingleChoice(SenderAndRecieversThreePersonsSingleChoice item)
        {
            try
            {
                _dataService.AddRecipient(item.Recipient1);
                _dataService.AddRecipient(item.Recipient2);
                _dataService.AddRecipient(item.Recipient3);
                _dataService.AddSender(item.sender);
                var item2 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient1,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item3 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient2,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item4 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient3,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                _dataService.AddWishCard(item2);
                _dataService.AddWishCard(item3);
                _dataService.AddWishCard(item4);
                GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item, item.sender.messagetoshow, item.GeneralBackgroundImageChoice, item.GeneralMp3Choice, item.GeneralFontChoice);
                return RedirectToAction("EndScreen", "EndScreen");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieversThreePersonsSingleChoice item2 = new SenderAndRecieversThreePersonsSingleChoice();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentNullException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieversThreePersonsSingleChoice item2 = new SenderAndRecieversThreePersonsSingleChoice();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieversThreePersonsSingleChoice item2 = new SenderAndRecieversThreePersonsSingleChoice();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
                return View(item2);
            }
        }



        public ActionResult FillInDataFourPersonsSingleChoice()
        {
            SenderAndRecieversFourPersonsSingleChoice item = new SenderAndRecieversFourPersonsSingleChoice();
            item.Recipient4 = new Models.Recipient();
            item.Recipient3 = new Models.Recipient();
            item.Recipient2 = new Models.Recipient();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            item.GeneralMp3Choice = new Enumerations.Mp3Enum();
            item.GeneralFontChoice = new Enumerations.FontsEnum();
            item.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInDataFourPersonsSingleChoice(SenderAndRecieversFourPersonsSingleChoice item)
        {
            try
            {
                _dataService.AddRecipient(item.Recipient1);
                _dataService.AddRecipient(item.Recipient2);
                _dataService.AddRecipient(item.Recipient3);
                _dataService.AddRecipient(item.Recipient4);
                _dataService.AddSender(item.sender);
                var item2 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient1,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item3 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient2,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item4 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient3,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item5 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient4,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                _dataService.AddWishCard(item2);
                _dataService.AddWishCard(item3);
                _dataService.AddWishCard(item4);
                _dataService.AddWishCard(item5);
                GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item, item.sender.messagetoshow, item.GeneralBackgroundImageChoice, item.GeneralMp3Choice, item.GeneralFontChoice);
                return RedirectToAction("EndScreen", "EndScreen");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieversFourPersonsSingleChoice item2 = new SenderAndRecieversFourPersonsSingleChoice();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentNullException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieversFourPersonsSingleChoice item2 = new SenderAndRecieversFourPersonsSingleChoice();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieversFourPersonsSingleChoice item2 = new SenderAndRecieversFourPersonsSingleChoice();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
                return View(item2);
            }
        }


        public ActionResult FillInDataFivePersonsSingleChoice()
        {
            SenderAndRecieverFivePersonsSingleChoice item = new SenderAndRecieverFivePersonsSingleChoice();
            item.Recipient5 = new Models.Recipient();
            item.Recipient4 = new Models.Recipient();
            item.Recipient3 = new Models.Recipient();
            item.Recipient2 = new Models.Recipient();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            item.GeneralMp3Choice = new Enumerations.Mp3Enum();
            item.GeneralFontChoice = new Enumerations.FontsEnum();
            item.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInDataFivePersonsSingleChoice(SenderAndRecieverFivePersonsSingleChoice item)
        {
            try
            {
                _dataService.AddRecipient(item.Recipient1);
                _dataService.AddRecipient(item.Recipient2);
                _dataService.AddRecipient(item.Recipient3);
                _dataService.AddRecipient(item.Recipient4);
                _dataService.AddRecipient(item.Recipient5);
                _dataService.AddSender(item.sender);
                var item2 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient1,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item3 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient2,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item4 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient3,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item5 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient4,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                var item6 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient5,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.GeneralFontChoice,
                    background = item.GeneralBackgroundImageChoice,
                    mp3 = item.GeneralMp3Choice

                };
                _dataService.AddWishCard(item2);
                _dataService.AddWishCard(item3);
                _dataService.AddWishCard(item4);
                _dataService.AddWishCard(item5);
                _dataService.AddWishCard(item6);
                GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item, item.sender.messagetoshow, item.GeneralBackgroundImageChoice, item.GeneralMp3Choice, item.GeneralFontChoice);
                return RedirectToAction("EndScreen", "EndScreen");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverFivePersonsSingleChoice item2 = new SenderAndRecieverFivePersonsSingleChoice();
                item2.Recipient5 = new Models.Recipient();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentNullException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverFivePersonsSingleChoice item2 = new SenderAndRecieverFivePersonsSingleChoice();
                item2.Recipient5 = new Models.Recipient();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverFivePersonsSingleChoice item2 = new SenderAndRecieverFivePersonsSingleChoice();
                item2.Recipient5 = new Models.Recipient();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                item2.GeneralMp3Choice = new Enumerations.Mp3Enum();
                item2.GeneralFontChoice = new Enumerations.FontsEnum();
                item2.GeneralBackgroundImageChoice = new Enumerations.BackgroundImageEnum();
                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
                return View(item);
            }
        }

        public ActionResult FillInDataMultipleChoice()
        {
            SenderAndRecieverOnePersonMultipleChoice item = new SenderAndRecieverOnePersonMultipleChoice();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            return View(item);
        }

        // POST: FillInDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInDataMultipleChoice(SenderAndRecieverOnePersonMultipleChoice item)
        {
            try
            {
                _dataService.AddRecipient(item.Recipient1);
                _dataService.AddSender(item.sender);
                var item2 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient1,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient1.StoreFont,
                    background = item.Recipient1.StoreBackgroundImage,
                    mp3 = item.Recipient1.StoreMp3

                };
                _dataService.AddWishCard(item2);
                GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item);
                return RedirectToAction("EndScreen", "EndScreen");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverOnePersonMultipleChoice item2 = new SenderAndRecieverOnePersonMultipleChoice();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentNullException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverOnePersonMultipleChoice item2 = new SenderAndRecieverOnePersonMultipleChoice();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverOnePersonMultipleChoice item2 = new SenderAndRecieverOnePersonMultipleChoice();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
                return View(item2);
            }
        }

        public ActionResult FillInDataTwoPersonsMultipleChoice()
        {
            SenderAndRecieverTwoPersonsMultipleChoice item = new SenderAndRecieverTwoPersonsMultipleChoice();
            item.Recipient2 = new Models.Recipient();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInDataTwoPersonsMultipleChoice(SenderAndRecieverTwoPersonsMultipleChoice item)
        {
            try
            {
                _dataService.AddRecipient(item.Recipient1);
                _dataService.AddRecipient(item.Recipient2);
                _dataService.AddSender(item.sender);
                var item2 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient1,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient1.StoreFont,
                    background = item.Recipient1.StoreBackgroundImage,
                    mp3 = item.Recipient1.StoreMp3

                };
                var item3 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient2,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient2.StoreFont,
                    background = item.Recipient2.StoreBackgroundImage,
                    mp3 = item.Recipient2.StoreMp3

                };
                _dataService.AddWishCard(item2);
                _dataService.AddWishCard(item3);
                GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item);
                return RedirectToAction("EndScreen", "EndScreen");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverTwoPersonsMultipleChoice item2 = new SenderAndRecieverTwoPersonsMultipleChoice();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentNullException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverTwoPersonsMultipleChoice item2 = new SenderAndRecieverTwoPersonsMultipleChoice();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverTwoPersonsMultipleChoice item2 = new SenderAndRecieverTwoPersonsMultipleChoice();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
                return View(item2);
            }
        }

        public ActionResult FillInDataThreePersonsMultipleChoice()
        {
            SenderAndRecieverThreePersonsMultipleChoice item = new SenderAndRecieverThreePersonsMultipleChoice();
            item.Recipient3 = new Models.Recipient();
            item.Recipient2 = new Models.Recipient();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInDataThreePersonsMultipleChoice(SenderAndRecieverThreePersonsMultipleChoice item)
        {
            try
            {
                _dataService.AddRecipient(item.Recipient1);
                _dataService.AddRecipient(item.Recipient2);
                _dataService.AddRecipient(item.Recipient3);
                _dataService.AddSender(item.sender);
                var item2 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient1,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient1.StoreFont,
                    background = item.Recipient1.StoreBackgroundImage,
                    mp3 = item.Recipient1.StoreMp3

                };
                var item3 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient2,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient2.StoreFont,
                    background = item.Recipient2.StoreBackgroundImage,
                    mp3 = item.Recipient2.StoreMp3

                };
                var item4 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient3,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient3.StoreFont,
                    background = item.Recipient3.StoreBackgroundImage,
                    mp3 = item.Recipient3.StoreMp3

                };
                _dataService.AddWishCard(item2);
                _dataService.AddWishCard(item3);
                _dataService.AddWishCard(item4);
                GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item);
                return RedirectToAction("EndScreen", "EndScreen");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverThreePersonsMultipleChoice item2 = new SenderAndRecieverThreePersonsMultipleChoice();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentNullException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverThreePersonsMultipleChoice item2 = new SenderAndRecieverThreePersonsMultipleChoice();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverThreePersonsMultipleChoice item2 = new SenderAndRecieverThreePersonsMultipleChoice();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
                return View(item2);
            }
        }



        public ActionResult FillInDataFourPersonsMultipleChoice()
        {
            SenderAndRecieverFourPersonsMultipleChoice item = new SenderAndRecieverFourPersonsMultipleChoice();
            item.Recipient4 = new Models.Recipient();
            item.Recipient3 = new Models.Recipient();
            item.Recipient2 = new Models.Recipient();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInDataFourPersonsMultipleChoice(SenderAndRecieverFourPersonsMultipleChoice item)
        {
            try
            {
                _dataService.AddRecipient(item.Recipient1);
                _dataService.AddRecipient(item.Recipient2);
                _dataService.AddRecipient(item.Recipient3);
                _dataService.AddRecipient(item.Recipient4);
                _dataService.AddSender(item.sender);
                var item2 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient1,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient1.StoreFont,
                    background = item.Recipient1.StoreBackgroundImage,
                    mp3 = item.Recipient1.StoreMp3

                };
                var item3 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient2,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient2.StoreFont,
                    background = item.Recipient2.StoreBackgroundImage,
                    mp3 = item.Recipient2.StoreMp3

                };
                var item4 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient3,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient3.StoreFont,
                    background = item.Recipient3.StoreBackgroundImage,
                    mp3 = item.Recipient3.StoreMp3

                };
                var item5 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient4,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient4.StoreFont,
                    background = item.Recipient4.StoreBackgroundImage,
                    mp3 = item.Recipient4.StoreMp3

                };
                _dataService.AddWishCard(item2);
                _dataService.AddWishCard(item3);
                _dataService.AddWishCard(item4);
                _dataService.AddWishCard(item5);
                GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item);
                return RedirectToAction("EndScreen", "EndScreen");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverFourPersonsMultipleChoice item2 = new SenderAndRecieverFourPersonsMultipleChoice();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentNullException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverFourPersonsMultipleChoice item2 = new SenderAndRecieverFourPersonsMultipleChoice();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverFourPersonsMultipleChoice item2 = new SenderAndRecieverFourPersonsMultipleChoice();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
                return View(item2);
            }
        }


        public ActionResult FillInDataFivePersonsMultipleChoice()
        {
            SenderAndRecieverFivePersonsMultipleChoice item = new SenderAndRecieverFivePersonsMultipleChoice();
            item.Recipient5 = new Models.Recipient();
            item.Recipient4 = new Models.Recipient();
            item.Recipient3 = new Models.Recipient();
            item.Recipient2 = new Models.Recipient();
            item.sender = new Models.SenderData();
            item.Recipient1 = new Models.Recipient();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FillInDataFivePersonsMultipleChoice(SenderAndRecieverFivePersonsMultipleChoice item)
        {
            try
            {
                _dataService.AddRecipient(item.Recipient1);
                _dataService.AddRecipient(item.Recipient2);
                _dataService.AddRecipient(item.Recipient3);
                _dataService.AddRecipient(item.Recipient4);
                _dataService.AddRecipient(item.Recipient5);
                _dataService.AddSender(item.sender);
                var item2 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient1,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient1.StoreFont,
                    background = item.Recipient1.StoreBackgroundImage,
                    mp3 = item.Recipient1.StoreMp3

                };
                var item3 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient2,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient2.StoreFont,
                    background = item.Recipient2.StoreBackgroundImage,
                    mp3 = item.Recipient2.StoreMp3

                };
                var item4 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient3,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient3.StoreFont,
                    background = item.Recipient3.StoreBackgroundImage,
                    mp3 = item.Recipient3.StoreMp3

                };
                var item5 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient4,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient4.StoreFont,
                    background = item.Recipient4.StoreBackgroundImage,
                    mp3 = item.Recipient4.StoreMp3

                };
                var item6 = new Models.WishCard()
                {
                    Id = Guid.NewGuid().ToString(),
                    Recipients = item.Recipient5,
                    sender = item.sender,
                    Text = item.sender.messagetoshow,
                    font = item.Recipient5.StoreFont,
                    background = item.Recipient5.StoreBackgroundImage,
                    mp3 = item.Recipient5.StoreMp3

                };
                _dataService.AddWishCard(item2);
                _dataService.AddWishCard(item3);
                _dataService.AddWishCard(item4);
                _dataService.AddWishCard(item5);
                _dataService.AddWishCard(item6);
                GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData(item);
                return RedirectToAction("EndScreen", "EndScreen");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverFivePersonsMultipleChoice item2 = new SenderAndRecieverFivePersonsMultipleChoice();
                item2.Recipient5 = new Models.Recipient();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentNullException ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverFivePersonsMultipleChoice item2 = new SenderAndRecieverFivePersonsMultipleChoice();
                item2.Recipient5 = new Models.Recipient();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Wrong value filled in try again');</script>");
                return View(item2);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                SenderAndRecieverFivePersonsMultipleChoice item2 = new SenderAndRecieverFivePersonsMultipleChoice();
                item2.Recipient5 = new Models.Recipient();
                item2.Recipient4 = new Models.Recipient();
                item2.Recipient3 = new Models.Recipient();
                item2.Recipient2 = new Models.Recipient();
                item2.sender = new Models.SenderData();
                item2.Recipient1 = new Models.Recipient();
                Response.WriteAsync("<script>alert('Something went wrong try again');</script>");
                return View(item2);
            }
        }
        #endregion
    }
}
