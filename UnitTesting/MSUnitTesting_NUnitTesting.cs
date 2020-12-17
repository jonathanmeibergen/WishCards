using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.CSVToIEnumerableConverters;
using WishCards.DAL;
using WishCards.Data;
using WishCards.Enumerations;
using WishCards.EventArgsNameSpace;
using WishCards.EventHandlers;
using WishCards.Interfaces;
using WishCards.Models;
using NUnit;
using NUnit.Framework;
using NUnit.Compatibility;

namespace WishCards.UnitTesting
{
    [TestClass]
    public class MSUnitTesting_NUnitTesting
    {
        [TestMethod]
        [TestCategory("CategorizationStructure")]
        [DynamicData(nameof(TestFontConvertion.TestFonts), typeof(TestFontConvertion))]
        public void FontTest(string value)
        {
            List<string> Fontcollection = new List<string>();
            Fontcollection.Add(FontsEnum.Courier.ToString());
            Fontcollection.Add(FontsEnum.Helvetica.ToString());
            Fontcollection.Add(FontsEnum.TimesNewRoman.ToString());
            Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.Contains(Fontcollection, value, "All regular items are inside the collection");
        }

        [TestMethod]
        [TestCategory("CategorizationStructure")]
        [DynamicData(nameof(TestMp3Convertion.TestMp3), typeof(TestMp3Convertion))]
        public void Mp3Test(string value)
        {
            List<string> mp3collection = new List<string>();
            mp3collection.Add(Mp3Enum.Jingle1.ToString());
            mp3collection.Add(Mp3Enum.Jingle2.ToString());
            mp3collection.Add(Mp3Enum.Jingle3.ToString());
            Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.Contains(mp3collection, value, "All regular items are inside the collection");
        }

        [TestMethod]
        [TestCategory("CategorizationStructure")]
        [DynamicData(nameof(TestFontColorConvertion.TestFontColor), typeof(TestFontColorConvertion))]
        public void ColorsTest(string value)
        {
            List<string> fontcolorcollection = new List<string>();
            fontcolorcollection.Add(ColorsEnum.AntiqueWhite.ToString());
            fontcolorcollection.Add(ColorsEnum.BlanchedAlmond.ToString());
            fontcolorcollection.Add(ColorsEnum.Crimson.ToString());
            fontcolorcollection.Add(ColorsEnum.DarkGoldenRod.ToString());
            fontcolorcollection.Add(ColorsEnum.DarkGreen.ToString());
            fontcolorcollection.Add(ColorsEnum.DarkTurquoise.ToString());
            Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.Contains(fontcolorcollection, value, "All regular items are inside the collection");
        }


        [TestMethod]
        [TestCategory("CategorizationStructure")]
        [DynamicData(nameof(TestBackgroundConvertion.TestFontColor), typeof(TestBackgroundConvertion))]
        public void BackgroundTest(string value)
        {
            List<string> Backgroundcollection = new List<string>();
            Backgroundcollection.Add(FontsEnum.Courier.ToString());
            Backgroundcollection.Add(FontsEnum.Helvetica.ToString());
            Backgroundcollection.Add(FontsEnum.TimesNewRoman.ToString());
            Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.Contains(Backgroundcollection, value, "All regular items are inside the collection");
        }


        [TestMethod]
        [TestCategory("MockDataMethodization")]
        public void GeneratingandAddingModelToMockdatabase()
        {
            IdataService _dataBase = MockDataService.GetMockDataService();
            Recipient model = new Recipient()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "Test@gmail.com",
                FirstName = "John",
                LastName = "Smith",
                StoreBackgroundImage = BackgroundImageEnum.Background1,
                StoreFont = FontsEnum.Courier,
                StoreMp3 = Mp3Enum.Jingle1
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_dataBase.AddRecipient(model), "Methods towards database working");
        }

        [TestMethod]
        [TestCategory("DataBaseMethodization")]
        public void GeneratingandAddingModelToDatabase()
        {
            WishCardDbData _database = WishCardDbData.GetDataService();
            WishCard model = new WishCard()
            {
                Id = Guid.NewGuid().ToString(),
                background = BackgroundImageEnum.Background1,
                font = FontsEnum.Courier,
                mp3 = Mp3Enum.Jingle1,
                Text = "test"
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(_database.AddWishCard(model), "Methods towards database working");
        }

        [TestMethod]
        [TestCategory("CheckDependancyDbContext")]
        public void DataBaseInheritedByIdentityContext()
        {
            var emptyvalue = new DbContextOptions<ApplicationDbContext>();
            ApplicationDbContext item = new ApplicationDbContext(emptyvalue);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(item, typeof(IdentityDbContext), "Methods towards database working");
        }

        [TestMethod]
        [TestCategory("CheckDependancyDbContext")]
        public void UseAndCorrectTypeDbSetWishCard()
        {
            var emptyvalue = new DbContextOptions<ApplicationDbContext>();
            var item = new ApplicationDbContext(emptyvalue);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(item.WishCards, typeof(DbSet<WishCard>), "Correct type used");
        }

        [TestMethod]
        [TestCategory("CheckDependancyDbContext")]
        public void UseAndCorrectTypeDbSetRecipient()
        {
            var emptyvalue = new DbContextOptions<ApplicationDbContext>();
            var item = new ApplicationDbContext(emptyvalue);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(item.Recipients, typeof(DbSet<Recipient>), "Correct type used");
        }

        [TestMethod]
        [TestCategory("CheckDependancyEventArgs")]
        public void ImplementedRightIneritedTypeEventargsGeneralChoice()
        {
            var item = new GeneralChoiceEventArgs();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(item, typeof(EventArgs), "Correct type inhertied");
        }

        [TestMethod]
        [TestCategory("CheckDependancyEventArgs")]
        public void ImplementedRightIneritedTypeEventargsMultipleChoice()
        {
            var item = new MultipleChoiceEventargs();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(item, typeof(EventArgs), "Correct type inherited");
        }

        [TestMethod]
        [TestCategory("CheckPdfAndSendCombinedFunctionWorkingGeneralChoice")]
        public void CheckPdfAndSendCombinedFunctionWorkingGeneralChoice()
        {
            ViewModel.SenderAndRecieversOnePersonSingleChoice viewmodel = new ViewModel.SenderAndRecieversOnePersonSingleChoice()
            {
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    emailadress = "test@gmail.com",
                    firstname = "John",
                    lastname = "Smith",
                },
                GeneralFontChoice = FontsEnum.Courier,
                GeneralBackgroundImageChoice = BackgroundImageEnum.Background1,
                GeneralMp3Choice = Mp3Enum.Jingle1,
                Recipient1 = new Recipient()
                {
                 Id = Guid.NewGuid().ToString(),
                 Email = "test@gmail.com",
                 FirstName = "John",
                 LastName = "Smith",
                 StoreBackgroundImage = BackgroundImageEnum.Background1,
                 StoreFont = FontsEnum.Courier,
                 StoreMp3 = Mp3Enum.Jingle1
                }
            };
            object[] value = new object[0]; 
            GeneralChoiceCustomEventHandler handler = new GeneralChoiceCustomEventHandler();
            Action action = () => handler.GenerateAndSendGeneralChoice(viewmodel,"test",viewmodel.GeneralBackgroundImageChoice,viewmodel.GeneralMp3Choice, viewmodel.GeneralFontChoice );
            NUnit.Framework.Assert.DoesNotThrow(() => action(), "Code's functionality not impended", value);
        }

        [TestMethod]
        [TestCategory("CheckPdfAndSendCombinedFunctionWorkingSingleChoice")]
        public void CheckPdfAndSendCombinedFunctionWorkingMultipleChoice()
        {
            ViewModel.SenderAndRecieverOnePersonMultipleChoice viewmodel = new ViewModel.SenderAndRecieverOnePersonMultipleChoice()
            {
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    emailadress = "test@gmail.com",
                    firstname = "John",
                    lastname = "Smith",
                },
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "John",
                    LastName = "Smith",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                }
            };
            object[] value = new object[0];
            MultipleChoiceCustomEventHandler handler = new MultipleChoiceCustomEventHandler();
            Action action = () => handler.GenerateAndSendMultipleChoice(viewmodel);
            NUnit.Framework.Assert.DoesNotThrow(() => action(), "Code's functionality not impended", value);
        }

        [TestMethod]
        [TestCategory("CheckExtensionMethods")]
        public void GenerateAndSendExtensionMethodTesting()
        {
            GeneralFunctions.GeneratePdfAndSendToRecipients item = new GeneralFunctions.GeneratePdfAndSendToRecipients();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(ExtensionMethods.GenerateAndSendPdfTesting.Working(item),"Extension method working");
        }

        [TestMethod]
        [TestCategory("CheckExtensionMethods")]
        public void ReturnPathExtensionMethodTesting()
        {
            GeneralFunctions.ReturnPathString item = new GeneralFunctions.ReturnPathString();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(ExtensionMethods.ReturnPathStringTesting.Working(item), "Extension method working");
        }


        [TestMethod]
        [TestCategory("CloningTesting")]
        public void TestCloning()
        {
            List<string> item = new List<string>()
            {
             "test"
            };

            List<string> item2 = GeneralFunctions.DeepCloning.DeepClone(item);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotSame(item, item2, "Cloning worked");
        }

        [TestMethod]
        [TestCategory("PdfGeneratorTesting")]
        public void TestPdfGenerator()
        {
            Action action = () => ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer("test", "test", "test", "test", BackgroundImageEnum.Background1, Mp3Enum.Jingle1, FontsEnum.Courier);
            NUnit.Framework.Assert.DoesNotThrow(() => action(), "Pdf Generator is functional");
        }


        [TestMethod]
        [TestCategory("Loggingtesting")]
        public void LoggingTest()
        {
            Action action = () => LoggingAndTracing.Log4Net.logging();
            NUnit.Framework.Assert.DoesNotThrow(() => action(), "Logging is functional");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void RecipientPropertiesTestingId()
        {
            Models.Recipient model = new Recipient()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                FirstName = "test",
                LastName = "test",
                StoreBackgroundImage = BackgroundImageEnum.Background1,
                StoreFont = FontsEnum.Courier,
                StoreMp3 = Mp3Enum.Jingle1
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Id, "Propertie working properly");      
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void RecipientPropertiesTestingEmail()
        {
            Models.Recipient model = new Recipient()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                FirstName = "test",
                LastName = "test",
                StoreBackgroundImage = BackgroundImageEnum.Background1,
                StoreFont = FontsEnum.Courier,
                StoreMp3 = Mp3Enum.Jingle1
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Email, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void RecipientPropertiesTestingFirstName()
        {
            Models.Recipient model = new Recipient()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                FirstName = "test",
                LastName = "test",
                StoreBackgroundImage = BackgroundImageEnum.Background1,
                StoreFont = FontsEnum.Courier,
                StoreMp3 = Mp3Enum.Jingle1
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.FirstName, "Propertie working properly");
        }



        [TestMethod]
        [TestCategory("ModelTesting")]
        public void RecipientPropertiesTestingLastName()
        {
            Models.Recipient model = new Recipient()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                FirstName = "test",
                LastName = "test",
                StoreBackgroundImage = BackgroundImageEnum.Background1,
                StoreFont = FontsEnum.Courier,
                StoreMp3 = Mp3Enum.Jingle1
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.LastName, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void RecipientPropertiesTestingBackground()
        {
            Models.Recipient model = new Recipient()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                FirstName = "test",
                LastName = "test",
                StoreBackgroundImage = BackgroundImageEnum.Background1,
                StoreFont = FontsEnum.Courier,
                StoreMp3 = Mp3Enum.Jingle1
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.StoreBackgroundImage, "Propertie working properly");
        }


        [TestMethod]
        [TestCategory("ModelTesting")]
        public void RecipientPropertiesTestingFont()
        {
            Models.Recipient model = new Recipient()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                FirstName = "test",
                LastName = "test",
                StoreBackgroundImage = BackgroundImageEnum.Background1,
                StoreFont = FontsEnum.Courier,
                StoreMp3 = Mp3Enum.Jingle1
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.StoreFont, "Propertie working properly");
        }


        [TestMethod]
        [TestCategory("ModelTesting")]
        public void RecipientPropertiesTestingMp3()
        {
            Models.Recipient model = new Recipient()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                FirstName = "test",
                LastName = "test",
                StoreBackgroundImage = BackgroundImageEnum.Background1,
                StoreFont = FontsEnum.Courier,
                StoreMp3 = Mp3Enum.Jingle1
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.StoreMp3, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void SenderPropertiesTestingId()
        {
            Models.SenderData model = new SenderData()
            {
             Id = Guid.NewGuid().ToString(),
             addition = "test",
             emailadress = "test@gmail.com",
             firstname = "test",
             lastname = "test",
             messagetoshow = "test"
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Id, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void SenderPropertiesTestingAddition()
        {
            Models.SenderData model = new SenderData()
            {
                Id = Guid.NewGuid().ToString(),
                addition = "test",
                emailadress = "test@gmail.com",
                firstname = "test",
                lastname = "test",
                messagetoshow = "test"
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.addition, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void SenderPropertiesTestingEmailAdress()
        {
            Models.SenderData model = new SenderData()
            {
                Id = Guid.NewGuid().ToString(),
                addition = "test",
                emailadress = "test@gmail.com",
                firstname = "test",
                lastname = "test",
                messagetoshow = "test"
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.emailadress, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void SenderPropertiesTestingFirstName()
        {
            Models.SenderData model = new SenderData()
            {
                Id = Guid.NewGuid().ToString(),
                addition = "test",
                emailadress = "test@gmail.com",
                firstname = "test",
                lastname = "test",
                messagetoshow = "test"
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.firstname, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void SenderPropertiesTestingLastName()
        {
            Models.SenderData model = new SenderData()
            {
                Id = Guid.NewGuid().ToString(),
                addition = "test",
                emailadress = "test@gmail.com",
                firstname = "test",
                lastname = "test",
                messagetoshow = "test"
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.lastname, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void SenderPropertiesTestingMessageToShow()
        {
            Models.SenderData model = new SenderData()
            {
                Id = Guid.NewGuid().ToString(),
                addition = "test",
                emailadress = "test@gmail.com",
                firstname = "test",
                lastname = "test",
                messagetoshow = "test"
            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.messagetoshow, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void WishCardPropertiesTestingId()
        {
            Models.WishCard model = new WishCard()
            {
                Id = Guid.NewGuid().ToString(),
                Recipients = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
              sender = new SenderData()
              {
                  Id = Guid.NewGuid().ToString(),
                  addition = "test",
                  emailadress = "test@gmail.com",
                  firstname = "test",
                  lastname = "test",
                  messagetoshow = "test"
              },
             background = BackgroundImageEnum.Background1,
             font = FontsEnum.Courier,
             mp3 = Mp3Enum.Jingle1,
             Text = "test"

            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Id, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void WishCardPropertiesTestingRecipient()
        {
            Models.WishCard model = new WishCard()
            {
                Id = Guid.NewGuid().ToString(),
                Recipients = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                },
                background = BackgroundImageEnum.Background1,
                font = FontsEnum.Courier,
                mp3 = Mp3Enum.Jingle1,
                Text = "test"

            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipients, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void WishCardPropertiesTestingSender()
        {
            Models.WishCard model = new WishCard()
            {
                Id = Guid.NewGuid().ToString(),
                Recipients = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                },
                background = BackgroundImageEnum.Background1,
                font = FontsEnum.Courier,
                mp3 = Mp3Enum.Jingle1,
                Text = "test"

            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void WishCardPropertiesTestingBackground()
        {
            Models.WishCard model = new WishCard()
            {
                Id = Guid.NewGuid().ToString(),
                Recipients = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                },
                background = BackgroundImageEnum.Background1,
                font = FontsEnum.Courier,
                mp3 = Mp3Enum.Jingle1,
                Text = "test"

            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.background, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void WishCardPropertiesTestingfont()
        {
            Models.WishCard model = new WishCard()
            {
                Id = Guid.NewGuid().ToString(),
                Recipients = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                },
                background = BackgroundImageEnum.Background1,
                font = FontsEnum.Courier,
                mp3 = Mp3Enum.Jingle1,
                Text = "test"

            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.font, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("ModelTesting")]
        public void WishCardPropertiesTestingMp3()
        {
            Models.WishCard model = new WishCard()
            {
                Id = Guid.NewGuid().ToString(),
                Recipients = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                },
                background = BackgroundImageEnum.Background1,
                font = FontsEnum.Courier,
                mp3 = Mp3Enum.Jingle1,
                Text = "test"

            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.mp3, "Propertie working properly");
        }


        [TestMethod]
        [TestCategory("ModelTesting")]
        public void WishCardPropertiesTestingText()
        {
            Models.WishCard model = new WishCard()
            {
                Id = Guid.NewGuid().ToString(),
                Recipients = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                },
                background = BackgroundImageEnum.Background1,
                font = FontsEnum.Courier,
                mp3 = Mp3Enum.Jingle1,
                Text = "test"

            };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Text, "Propertie working properly");
        }

        [TestMethod]
        [TestCategory("SendDataTest")]
        public void MailingTest()
        {
            Action action = () => SmtpMailService.SendCustomerMail.SendMailToCustomer
            (
                "Test@gmail.com",
                ITextSharpPdfCreator.GeneratefileForCustomers.GeneratePdfFileForCustomer("test", "test", "test", "test", BackgroundImageEnum.Background1, Mp3Enum.Jingle1, FontsEnum.Courier),
                Mp3Enum.Jingle1
            );
            NUnit.Framework.Assert.DoesNotThrow(() => action(), "Mailing is functional");

        }

        [TestMethod]
        [TestCategory("TestViewModels")]
        public void OnePersonGeneralChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieversOnePersonSingleChoice model = new ViewModel.SenderAndRecieversOnePersonSingleChoice()
            {
                GeneralBackgroundImageChoice = BackgroundImageEnum.Background1,
                GeneralFontChoice = FontsEnum.Courier,
                GeneralMp3Choice = Mp3Enum.Jingle1,
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralBackgroundImageChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralFontChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralMp3Choice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");

        }

        [TestMethod]
        [TestCategory("TestViewModels")]
        public void TwoPersonsGeneralChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieversTwoPersonsSingleChoice model = new ViewModel.SenderAndRecieversTwoPersonsSingleChoice()
            {
                GeneralBackgroundImageChoice = BackgroundImageEnum.Background1,
                GeneralFontChoice = FontsEnum.Courier,
                GeneralMp3Choice = Mp3Enum.Jingle1,
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient2 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralBackgroundImageChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralFontChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralMp3Choice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient2, "Propertie working properly");

        }


        [TestMethod]
        [TestCategory("TestViewModels")]
        public void ThreePersonsGeneralChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieversThreePersonsSingleChoice model = new ViewModel.SenderAndRecieversThreePersonsSingleChoice()
            {
                GeneralBackgroundImageChoice = BackgroundImageEnum.Background1,
                GeneralFontChoice = FontsEnum.Courier,
                GeneralMp3Choice = Mp3Enum.Jingle1,
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient2 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient3 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralBackgroundImageChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralFontChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralMp3Choice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient2, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient3, "Propertie working properly");

        }

        [TestMethod]
        [TestCategory("TestViewModels")]
        public void FourPersonsGeneralChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieversFourPersonsSingleChoice model = new ViewModel.SenderAndRecieversFourPersonsSingleChoice()
            {
                GeneralBackgroundImageChoice = BackgroundImageEnum.Background1,
                GeneralFontChoice = FontsEnum.Courier,
                GeneralMp3Choice = Mp3Enum.Jingle1,
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient2 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient3 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient4 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralBackgroundImageChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralFontChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralMp3Choice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient2, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient3, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient4, "Propertie working properly");

        }

        [TestMethod]
        [TestCategory("TestViewModels")]
        public void FivePersonsGeneralChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieverFivePersonsSingleChoice model = new ViewModel.SenderAndRecieverFivePersonsSingleChoice()
            {
                GeneralBackgroundImageChoice = BackgroundImageEnum.Background1,
                GeneralFontChoice = FontsEnum.Courier,
                GeneralMp3Choice = Mp3Enum.Jingle1,
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient2 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient3 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient4 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient5 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralBackgroundImageChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralFontChoice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.GeneralMp3Choice, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient2, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient3, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient4, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient5, "Propertie working properly");

        }


        [TestMethod]
        [TestCategory("TestViewModels")]
        public void OnePersonMultipleChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieverOnePersonMultipleChoice model = new ViewModel.SenderAndRecieverOnePersonMultipleChoice()
            {
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");

        }

        [TestMethod]
        [TestCategory("TestViewModels")]
        public void TwoPersonsMultipleChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieverTwoPersonsMultipleChoice model = new ViewModel.SenderAndRecieverTwoPersonsMultipleChoice()
            {
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient2 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient2, "Propertie working properly");

        }

        [TestMethod]
        [TestCategory("TestViewModels")]
        public void ThreePersonsMultipleChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieverThreePersonsMultipleChoice model = new ViewModel.SenderAndRecieverThreePersonsMultipleChoice()
            {
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient2 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient3 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient2, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient3, "Propertie working properly");

        }

        [TestMethod]
        [TestCategory("TestViewModels")]
        public void FourPersonsMultipleChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieverFourPersonsMultipleChoice model = new ViewModel.SenderAndRecieverFourPersonsMultipleChoice()
            {
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient2 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient3 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient4 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient2, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient3, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient4, "Propertie working properly");

        }


        [TestMethod]
        [TestCategory("TestViewModels")]
        public void FivePersonsMultipleChoiceViewmodelTest()
        {
            ViewModel.SenderAndRecieverFivePersonsMultipleChoice model = new ViewModel.SenderAndRecieverFivePersonsMultipleChoice()
            {
                Recipient1 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient2 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient3 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient4 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                Recipient5 = new Recipient()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@gmail.com",
                    FirstName = "test",
                    LastName = "test",
                    StoreBackgroundImage = BackgroundImageEnum.Background1,
                    StoreFont = FontsEnum.Courier,
                    StoreMp3 = Mp3Enum.Jingle1
                },
                sender = new SenderData()
                {
                    Id = Guid.NewGuid().ToString(),
                    addition = "test",
                    emailadress = "test@gmail.com",
                    firstname = "test",
                    lastname = "test",
                    messagetoshow = "test"
                }
            };

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.sender, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient1, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient2, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient3, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient4, "Propertie working properly");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(model.Recipient5, "Propertie working properly");

        }
    }
}
