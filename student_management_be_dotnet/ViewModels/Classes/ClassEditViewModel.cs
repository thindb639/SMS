namespace student_management_be_dotnet.ViewModels.Classes;

// Same fields and validation as create, plus the Id of the class being edited
public class ClassEditViewModel : ClassCreateViewModel
{
    public long Id { get; set; }
}
