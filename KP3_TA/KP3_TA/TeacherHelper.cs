using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP3_TA
{
    class TeacherHelper
    {
        private List<Student> _groupList;
        private readonly Stack<Student> _groupStack = new();

        public TeacherHelper(List<Student> students)
        {
            _groupList = students ?? throw new ArgumentNullException(nameof(students));
        }

        public void FillStack()
        {
            _groupList.OrderBy(pair => pair.GroupCode)
                      .ThenByDescending(pair => pair.Name)
                      .ToList()
                      .ForEach(_groupStack.Push);
        }

        public Student? PopNext()
        {
            return _groupStack.Count > 0 ? _groupStack.Pop() : null;
        }

    }
    class Student
    {
        public string Name { get; set; } = string.Empty;
        public string GroupCode { get; set; } = string.Empty;
        public int? Mark { get; private set; } = null;

        public Student(string name, string groupCode)
        {
            Name = name;
            GroupCode = groupCode;
        }

        public void GiveMark(int value)
        {
            Mark = value;
        }

    }
}

