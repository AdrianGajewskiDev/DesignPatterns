using System;
using System.Text;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var csImplementation = new CSharpClassBuilder("User");
            var tsImplementation = new TypeScriptClassBuilder("User");

            ConstructClass(csImplementation);
            ConstructClass(tsImplementation);

            Console.WriteLine(csImplementation.Build());
            Console.WriteLine(tsImplementation.Build());

            Console.ReadLine();
        }

        static void ConstructClass(IClassBuilder builder)
        {
            builder
                .AddProperty("string", "Name")
                .AddProperty("string", "Email")
                .AddProperty("int", "Age")
                .AddMethod("void", "DeleteUser");
        }

    }

    //let say we wanna create class based on the programming language

    public interface IClassBuilder
    {
        IClassBuilder AddProperty(string propType, string propName);
        IClassBuilder AddMethod(string returnType, string methodName);
        string Build();
    }

    public class CSharpClassBuilder : IClassBuilder
    {
        private StringBuilder classImplementation;


        public CSharpClassBuilder(string className)
        {
            classImplementation = new StringBuilder().Append($"public class {className}" + Environment.NewLine + "{" + Environment.NewLine);
        }

        public IClassBuilder AddMethod(string returnType, string methodName)
        {
            classImplementation.Append($"public {returnType} {methodName}()" + Environment.NewLine);
            classImplementation.Append("{" + Environment.NewLine);
            classImplementation.Append(Environment.NewLine);
            classImplementation.Append("}" + Environment.NewLine);

            return this;
        }

        public IClassBuilder AddProperty(string propType, string propName)
        {
            classImplementation.Append($"public {propType} {propName} " + "{get; set; }" + Environment.NewLine);

            return this;
        }

        public string Build()
        {
            return classImplementation.Append(Environment.NewLine + "}").ToString();
        }
    }

    public class TypeScriptClassBuilder : IClassBuilder
    {

        private StringBuilder classImplementation;

        public TypeScriptClassBuilder(string className)
        {
            classImplementation = new StringBuilder().Append($"export class {className}" + Environment.NewLine + "{" + Environment.NewLine);

        }

        public IClassBuilder AddMethod(string returnType, string methodName)
        {
            classImplementation.Append($"{methodName}()" + Environment.NewLine);
            classImplementation.Append("{" + Environment.NewLine);
            classImplementation.Append(Environment.NewLine);
            classImplementation.Append("}" + Environment.NewLine);

            return this;
        }

        public IClassBuilder AddProperty(string propType, string propName)
        {
            classImplementation.Append($"{propName}: {propType};" + Environment.NewLine);
            return this;
        }

        public string Build()
        {
            return classImplementation.Append(Environment.NewLine + "}").ToString();
        }
    }
}
