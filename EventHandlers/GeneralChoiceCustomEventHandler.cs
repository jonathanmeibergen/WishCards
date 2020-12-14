using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishCards.Enumerations;

namespace WishCards.EventHandlers
{
    #region custom eventhandlers
    public class GeneralChoiceCustomEventHandler
    {
        public GeneralChoiceCustomEventHandler item = new GeneralChoiceCustomEventHandler();

        public delegate void GenerateAndSendDataSingleDelegate(ViewModel.SenderAndRecieversOnePersonSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font);

        public event GenerateAndSendDataSingleDelegate SingleGeneralChoiceEvent;

        public void GenerateAndSendGeneralChoice(ViewModel.SenderAndRecieversOnePersonSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {
            var item2 = new GenerateAndSendDataSingleDelegate(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.SingleGeneralChoiceEvent += item2;
            item.SingleGeneralChoiceEvent(model, contenttext, background, song, font);
            item.SingleGeneralChoiceEvent -= item2;
        }

        public delegate void GenerateAndSendDataDoubleDelegate(ViewModel.SenderAndRecieversTwoPersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font);

        public event GenerateAndSendDataDoubleDelegate DoubleGeneralChoiceEvent;

        public void GenerateAndSendGeneralChoice(ViewModel.SenderAndRecieversTwoPersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {
            var item2 = new GenerateAndSendDataDoubleDelegate(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.DoubleGeneralChoiceEvent += item2;
            item.DoubleGeneralChoiceEvent(model, contenttext, background, song, font);
            item.DoubleGeneralChoiceEvent -= item2;
        }

        public delegate void GenerateAndSendDataTripleDelegate(ViewModel.SenderAndRecieversThreePersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font);

        public event GenerateAndSendDataTripleDelegate TripleGeneralChoiceEvent;

        public void GenerateAndSendGeneralChoice(ViewModel.SenderAndRecieversThreePersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {
            var item2 = new GenerateAndSendDataTripleDelegate(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.TripleGeneralChoiceEvent += item2;
            item.TripleGeneralChoiceEvent(model, contenttext, background, song, font);
            item.TripleGeneralChoiceEvent -= item2;
        }

        public delegate void GenerateAndSendDataQuadropleDelegate(ViewModel.SenderAndRecieversFourPersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font);

        public event GenerateAndSendDataQuadropleDelegate QuadrupleGeneralChoiceEvent;

        public void GenerateAndSendGeneralChoice(ViewModel.SenderAndRecieversFourPersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {
            var item2 = new GenerateAndSendDataQuadropleDelegate(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.QuadrupleGeneralChoiceEvent += item2;
            item.QuadrupleGeneralChoiceEvent(model, contenttext, background, song, font);
            item.QuadrupleGeneralChoiceEvent -= item2;
        }

        public delegate void GenerateAndSendDataQuintupleDelegate(ViewModel.SenderAndRecieverFivePersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font);

        public event GenerateAndSendDataQuintupleDelegate QuintupleGeneralChoiceEvent;

        public void GenerateAndSendGeneralChoice(ViewModel.SenderAndRecieverFivePersonsSingleChoice model, string contenttext, BackgroundImageEnum background, Mp3Enum song, FontsEnum font)
        {
            var item2 = new GenerateAndSendDataQuintupleDelegate(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.QuintupleGeneralChoiceEvent += item2;
            item.QuintupleGeneralChoiceEvent(model, contenttext, background, song, font);
            item.QuintupleGeneralChoiceEvent -= item2;
        }

        #endregion

    }
}
