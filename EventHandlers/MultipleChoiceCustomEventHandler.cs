using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WishCards.EventHandlers
{
    public class MultipleChoiceCustomEventHandler
    {
        #region multiple input custom eventhandler 

        public MultipleChoiceCustomEventHandler item = new MultipleChoiceCustomEventHandler();

        public delegate void GenerateAndSendDataSingleDelegateMultiple(ViewModel.SenderAndRecieverOnePersonMultipleChoice model);

        public event GenerateAndSendDataSingleDelegateMultiple SingleMultipleChoiceEvent;

        public void GenerateAndSendMultipleChoice(ViewModel.SenderAndRecieverOnePersonMultipleChoice model)
        {
            var item2 = new GenerateAndSendDataSingleDelegateMultiple(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.SingleMultipleChoiceEvent += item2;
            item.SingleMultipleChoiceEvent(model);
            item.SingleMultipleChoiceEvent -= item2;
        }

        public delegate void GenerateAndSendDataDoubleDelegateMultiple(ViewModel.SenderAndRecieverTwoPersonsMultipleChoice model);

        public event GenerateAndSendDataDoubleDelegateMultiple DoubleMultipleChoiceEvent;

        public void GenerateAndSendMultipleChoice(ViewModel.SenderAndRecieverTwoPersonsMultipleChoice model)
        {
            var item2 = new GenerateAndSendDataDoubleDelegateMultiple(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.DoubleMultipleChoiceEvent += item2;
            item.DoubleMultipleChoiceEvent(model);
            item.DoubleMultipleChoiceEvent -= item2;
        }

        public delegate void GenerateAndSendDataTripleDelegateMultiple(ViewModel.SenderAndRecieverThreePersonsMultipleChoice model);

        public event GenerateAndSendDataTripleDelegateMultiple TripleMultipleChoiceEvent;

        public void GenerateAndSendMultipleChoice(ViewModel.SenderAndRecieverThreePersonsMultipleChoice model)
        {
            var item2 = new GenerateAndSendDataTripleDelegateMultiple(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.TripleMultipleChoiceEvent += item2;
            item.TripleMultipleChoiceEvent(model);
            item.TripleMultipleChoiceEvent -= item2;
        }

        public delegate void GenerateAndSendDataQuadrupleDelegateMultiple(ViewModel.SenderAndRecieverFourPersonsMultipleChoice model);

        public event GenerateAndSendDataQuadrupleDelegateMultiple QuadrupleMultipleChoiceEvent;

        public void GenerateAndSendMultipleChoice(ViewModel.SenderAndRecieverFourPersonsMultipleChoice model)
        {
            var item2 = new GenerateAndSendDataQuadrupleDelegateMultiple(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.QuadrupleMultipleChoiceEvent += item2;
            item.QuadrupleMultipleChoiceEvent(model);
            item.QuadrupleMultipleChoiceEvent -= item2;
        }

        public delegate void GenerateAndSendDataQuintupleDelegateMultiple(ViewModel.SenderAndRecieverFivePersonsMultipleChoice model);

        public event GenerateAndSendDataQuintupleDelegateMultiple QuintupleMultipleChoiceEvent;

        public void GenerateAndSendMultipleChoice(ViewModel.SenderAndRecieverFivePersonsMultipleChoice model)
        {
            var item2 = new GenerateAndSendDataQuintupleDelegateMultiple(GeneralFunctions.GeneratePdfAndSendToRecipients.GenerateAndSendData);
            item.QuintupleMultipleChoiceEvent += item2;
            item.QuintupleMultipleChoiceEvent(model);
            item.QuintupleMultipleChoiceEvent -= item2;
        }

        #endregion
    }
}
