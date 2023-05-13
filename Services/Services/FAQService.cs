using Models;

namespace Services
{
    public class FAQService : IFAQService
    {
        public FAQService()
        {
        }

        public IEnumerable<FAQDetailsDto> GetFAQList()
        {
            // TODO: Get values from database

            return FAQLIST;
        }

        private IEnumerable<FAQDetailsDto> FAQLIST
        {
            get => new List<FAQDetailsDto>()
            {
                new FAQDetailsDto
                {
                    Question = "Should I cancel my appointment because my period has started?",
                    Answer = "No, Gynaecological examination, ultrasound and Pap Smear can all be done during a period. " +
                    "If you have a bleeding problem you do not need to wait for a gap in the bleeding episode to make an appointment."
                },
                new FAQDetailsDto
                {
                    Question = "Does Dr Newham do Obstetrics/deliver babies?",
                    Answer = "No, Obstetrics is defined as care of a pregnancy beyond 20 weeks gestation. I stopped this part of my practice in 2017 after having done it for the previous 25 years.\n\n" +
                    "This  means that for pregnant patients you would be transferred to one of my colleges at 20 weeks to continue your antenatal care and deliver your baby. I would provide the care of the first trimester. " +
                    "This includes managing early pregnancy and it’s complications as well as screening for fetal abnormalities and risks for the pregnancy."
                },
                new FAQDetailsDto
                {
                    Question = "What does a Consultation include and what does it cost?",
                    Answer = ""
                },
                new FAQDetailsDto
                {
                    Question = "What is a follow up visit and what does that cost?",
                    Answer = ""
                },
                new FAQDetailsDto
                {
                    Question = "What other costs should I be aware of?",
                    Answer = "Special investigations with Pathologists/Radiologists are common. Here is a list of some you may one day need.\n" +
                       "These are approximations of coarse but we can give you an exact quote on the day, before requesting the investigation.\n\n" +
                       "Pap Smear: R303.20\n" +
                       "13 week Fetal scan: R2600.00 (outsourced to Fetal assessment centre)\n" +
                       "20 week Fetal scan: R2800.00 (outsourced to Fetal assessment centre)\n" +
                       "Insertion of Intra-uterine Contraceptive Device: R1000.00\n" +
                       "Endometrial biopsy: R1000.00\n\n" +
                       "Hormone levels via Pathcare:\n" +
                       "- Thyroid R404.30\n" +
                       "- Estrogen R255.50\n" +
                       "- Insulin Resistance R330.20\n" +
                       "- Testosterone R511.00"
                } ,
                new FAQDetailsDto
                {
                    Question = "How often should I come for a routine check up?",
                    Answer = "The usual advice is to have an annual check up and Pap smear. This does depend on age and individual risks."
                },
            };
        }
    }
}
