using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum GroupOptions
    {
        Exit,
        CreateGroup,
        UpdateGroup,
        DeleteGroup,
        GetAll,
        AllGroup,
        GetGroupByName,
        BackMainMenu,

    }
    public enum StudentOptions
    {
        Exit,
        CreateStudent,
        UpdateStudent,
        DeleteStudent,
        GetAllStudentByGroup,
        GetStudentByGroup,
        BackMainMenu,
    }
    public enum TeacherOptions
    {

        Exit,
        CreateTacher,
        UpdateTeacher,
        DeleteTeacher,
        GetAll,
        AddGroupToTeacher,
        GetAllGroupsToTeacher,
        BackMainMenu,
    }

}
