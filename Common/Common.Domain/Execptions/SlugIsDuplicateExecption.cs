namespace Common.Domain.Execptions
{
    public class SlugIsDuplicateExecption : BaseDomainException
    {
        public SlugIsDuplicateExecption() : base("اسلاگ تکراری است")
        {
        }
        public SlugIsDuplicateExecption(string message) : base(message)
        {
        }


    }
}
