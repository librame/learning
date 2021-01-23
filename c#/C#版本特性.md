# C# 各版本特性（1.0-8.0）

| 语言版本 | 框架支持               | 开发工具                 | 发布时间 |
| ------- | --------------------- | ----------------------- | ------- |
| C# 1.0  | .NET Framework 1.0    | Visual Studio .NET 2002 | 01/2002 |
| C# 1.1 & 1.2 | .NET  Framework 1.1             | Visual  Studio .NET 2003      | 04/2003  |
| C# 2.0        | .NET  Framework 2.0             | Visual  Studio 2005           | 11/2005  |
| C# 3.0        | .NET  Framework 2.0 / 3.0 / 3.5 | Visual  Studio 2008           | 11/2007  |
| C# 4.0        | .NET  Framework 4               | Visual  Studio 2010           | 04/2010  |
| C# 5.0        | .NET  Framework 4.5             | Visual  Studio 2012 / 2013    | 08/2012  |
| C# 6.0        | .NET  Framework 4.6             | Visual  Studio 2015           | 07/2015  |
| C# 7.0        | .NET  Framework 4.6.2           | Visual  Studio 2017           | 03/2017  |
| C# 7.1        | .NET  Framework 4.7             | Visual  Studio 2017 v15.3 Pre | 06/2017  |
| C# 7.2        | .NET  Framework 4.7.1           | Visual  Studio 2017 v15.5     | 11/2017  |
| C# 7.3        | .NET  Framework 4.7.2           | Visual  Studio 2017 v15.7     | 05/2018  |
| C# 8.0        | .NET  Framework ?               | Visual  Studio 2019           | ?/2019   |

 

# **C# 1.0**

1 类（Classes）

面向对象特性，支持类类型。

 

2 结构（Structs）

 

3 接口（Interfaces）

 

4 事件（Events）

 

5 属性（Properties）

类的成员，提供访问字段的灵活方法。

 

6 委托（Delegates）

一种引用类型，表示对具有特定参数列表和返回类型的方法的引用。

 

7 表达式、语句、操作符（Expressions, Statements, Operators）

 

8 特性（Attributes）

为程序代码添加元数据或声明性信息。运行时，通过反射可以访问特性信息。

 

9 字面值/常量值（Literals）

区别常量，常量是和变量相对的。

 

# **C# 2.0**

## 1 泛型（Generics）

1.1 作用

可在类、方法中对使用的类型进行参数化。

 

```
class MyCollection<T>
{
  private T _obj;
  
  public void Add(T obj)
  {
    //...
  }
}
 
MyCollection<string> items = new MyCollection<string>();
items.Add(string.Empty);
```

 

1.2 优势

- 编译时可以保证类型安全；
- 不用做装箱拆箱的类型转换，提升性能。

 

1.3 约束（Constraints）

可以给泛型的类型参数上加约束，以表示这些类型参数需满足一定的条件。

| 约束                     | 说明                               |
| ------------------------ | ---------------------------------- |
| where T :  struct        | 类型参数需是值类型                 |
| where T : class          | 类型参数需是引用类型               |
| where T :  new()         | 类型参数需有一个公共的无参构造函数 |
| where T :  BaseClassName | 类型参数需派生自某个基类           |
| where T :  InterfaceName | 类型参数需实现了某个接口           |
| where T :  B             | T 和 B 都是类型参数，T 需派生自 B  |

这些约束也可一起使用：

 

```
class MyDictionary<T, B>
  where B : IDisposable
  where T : class, new()
{
  //…
}
```

 

## 2 迭代器（Iterator）

可以在不实现 IEnumerable 就能使用 foreach 语句，在编译器碰到 yield return 时，它会自动生成 IEnumerable 接口的方法。在实现迭代器的方法或属性中，返回类型必须是 IEnumerable, IEnumerator, IEnumerable<T>，或 IEnumerator<T>。

迭代器使得遍历一些零碎数据的时候很方便，不用去实现 Current, MoveNext 这些方法。

 

```
public System.Collections.IEnumerator GetEnumerator()
{
  yield return -1;
 
  for (int i = 1; i < max; i++)
    yield return i;
}
```

 

## 3 可空类型（Nullable Type）

可空类型仅针对于值类型，不能针对引用类型去创建。System.Nullable<T> 简写为 T?。

 

```
int? num = null;
if (num.HasValue == true)
{
  System.Console.WriteLine("num = " + num.Value);
} else {
  System.Console.WriteLine("num = Null");
}
```

 

如果 HasValue 为 false，那么在使用 value 值的时候会抛出异常。把一个 Nullable 的变量 x 赋值给一个非 Nullable 的变量 y 可以这么写：

 

```
int y = x ?? -1;
```

 

## 4 匿名方法（Anonymous Method）

在 C#2.0 之前，给只能用一个已经申明好的方法去创建一个委托。有了匿名方法后，可以在创建委托的时候直接传一个代码块过去。

 

```
delegate void Del(int x);
Del d = delegate(int k) { /* ... */ };
System.Threading.Thread t1 = new System.Threading.Thread(delegate() {
  System.Console.WriteLine("Hello World!");
});
```

 

委托语法的简化

```
// C# 1.0 的写法 ThreadStart ts1 = new ThreadStart(Method1);
// C# 2.0 可以这么写 ThreadStart ts2 = Method1;
```

 

## 5 委托的协变和逆变（Covariance and Contravariance）

有下面的两个类：

 

```
class Parent { }
class Child: Parent { }
```

 

然后看下面的两个委托：

 

```
public delegate Parent DelgParent(); 
public delegate Child DelgChild(); 
 
public static Parent Method1() { return null; } 
public static Child Method2() { return null; } 
 
static void Main()
{
  DelgParent del1= Method1;
  DelgChild del2= Method2;
  del1 = del2;
}
```

 

注意上面的，DelgParent 和 DelgChild 是完全不同的类型，他们之间本身没有任何的继承关系，所以理论上来说他们是不能相互赋值的。但是因为协变的关系，使得我们可以把 DelgChild 类型的委托赋值给 DelgParent 类型的委托。协变针对委托的返回值，逆变针对参数，原理是一样的。

 

## 6 新增关键字

6.1 default

表示默认，可用于类型参数：

 

```
return default(T);
```

 

如果类型参数是值类型，则返回默认值；如果是引用类型，则返回 null；如果是结构体类型，则会返回一个默认实例。

 

6.2 partial

在申明一个类、结构或者接口的时候，用 partial 关键字，可以让源代码分布在不同的文件中。

部分类仅是编译器提供的功能，在编译的时候会把 partial 关键字定义的类和在一起去编译，和 CLR 没什么关系。

 

6.3 static class

静态类表示一个只能有静态成员的类，用 static 关键字对类进行标示。

静态类不能被实例化。

静态类理论上相当于一个只有静态成员并且构造函数为私有的普通类，静态类相对来说的好处就是，编译器能够保证静态类不会添加任何非静态成员。

 

6.4 global::

标示最上层命名空间。

 

```
global::System.Console.WriteLine(string.Empty);
```

 

6.5 fixed

可以使用 fixed 关键字来创建固定长度的数组，但是数组类型只能是基础值类型。

 

```
fixed char pathName[128];
```

 

6.6 volatile

表示相关的字可能被多个线程同时访问，编译器不会对相应的值做针对单线程下的优化，保证相关的值在任何时候访问都是最新的。

 

6.7 #pragma warning

用来取消或者添加编译时的警告信息。每个警告信息都会有个编号，如果 warning CS01016 之类的，使用的时候取 CS 后面的那个数字，例如：

 

```
#pragma warning disable 414, 3021
```

 

这样 CS414 和 CS3021 的警告信息就都不会显示了。

 

# **C# 3.0**

## 1 类型推断

申明变量的时候，可以不用直指定类型：

 

```
var i = 5;  // int
var s = "Hello";  // string
var b = new[] { 1, 1.5, 2, 2.5 };  // double[]
var c = new[] { "hello", null, "world” };  // string[]
```

 

## 2 扩展方法

扩展方法必须被定义在静态类中，并且必须是非泛型、非嵌套的静态类。例如：

 

```
public static class StringExtensions
{
  public static int ToInt32(this string s)
  {
    return Int32.Parse(s);
  }
 
  public static T[] SomeMethd<T>(this T[] source, int pram1, int pram2)
  {
    //…
  }
}
```

 

上面一个是给 string 类型的对象添加了一个方法，另一个是给所有类型的数组添加了一个方法，方法有两个整型参数。

扩展方法只在当前的命名空间类有效，如果所在命名空间被其它命名空间 import 引用了，那么在其它命名空间中也有效。

扩展方法的优先级低于其它的常规方法，也就是说如果扩展方法与其它的方法相同，那么扩展方法不会被调用。

 

## 3 Lambda 表达式

使用 => 为 Lambda 运算符，该运算符读为“goes to”。

可将此表达式分配给委托类型：

 

```
delegate int del(int i);
del myDelegate = x => x * x;
var j = myDelegate(5); // j = 25
```

 

也可将此表达式装换为表达式树类型：

 

```
Expression<del> exp = x => x * x;
 
```

## 4 表达式树

```
 
Func<int,int> f = x => x + 1;
Expression<Func<int,int>> e = x => x + 1;
```

 

## 5 对象和集合的初始化

 

```
var contacts = new List<Contact> {
  new Contact {
   Name = "Chris",
   PhoneNumbers = { "123455", "6688" }
  },
  new Contact {
   Name = "Jeffrey",
   PhoneNumbers = { "112233" }
  }
};
```

 

## 6 匿名类型

 

```
var p1 = new { Name = "Lawnmower", Price = 495.00 };
var p2 = new { Name = "Shovel", Price = 26.95 };
p1 = p2;
```

 

## 7 自动属性

会自动生成一个后台的私有变量。

 

```
public Class Point
{
  public int X { get; set; }
  public int Y { get; set; }
}
```

 

## 8 查询表达式

这个其实就是扩展方法的运用，编译器提供了相关的语法便利，下面两端代码是等价的：

 

```
from g in
  from c in customers
  group c by c.Country
select new { Country = g.Key, CustCount = g.Count() }
 
customers.
  GroupBy(c => c.Country).
  Select(g => new { Country = g.Key, CustCount = g.Count() })
```

 

# **C# 4.0**

## 1 泛型的协变和逆变

这个在 C#2.0 中就已经支持委托的协变和逆变了，C#4.0 开始支持针对泛型接口的协变和逆变：

 

```
IList<string> strings = new List<string>();
IList<object> objects = strings;
```

 

协变和逆变仅针对引用类型。

 

## 2 动态绑定

 

```
class BaseClass
{
  public void print()
  {
    Console.WriteLine(string.Empty);
  }
}
 
Object o = new BaseClass();
dynamic a = o; // 这里可以调用print方法，在运行时 a 会知道自己是个什么类型。缺点在于编译的时候无法检查方法的合法性，写错的话就会出运行时错误。
a.print();
```

 

## 3 可选、命名参数

可给参数设定默认值，以免去写重载麻烦。

 

```
private void Create(string frist, int second = 1)
{
  //…
}
```

 

调用方法的时候，可以指定参数的名字来给值，不用按照方法参数的顺序来制定参数值：

 

```
Create(second: 2, frist: "one");
```

 

# **C# 5.0**

## 1 异步编程

在 .Net Framework 4.5 中，通过 async 和 await 两个关键字，引入了一种新的基于任务的异步编程模型（TAP）。在这种方式下，可以通过类似同步方式编写异步代码，极大简化了异步编程模型。如下式一个简单的实例：

 

```
static async void DownloadStringAsync2(Uri uri)
{
  var webClient = new WebClient();
  var result = await webClient.DownloadStringTaskAsync(uri);
  Console.WriteLine(result);
}
```

 

而之前的方式是这样的：

 

```
static void DownloadStringAsync(Uri uri)
{
  var webClient = new WebClient();
  webClient.DownloadStringCompleted += (s, e) =>     {
      Console.WriteLine(e.Result);
    };
  webClient.DownloadStringAsync(uri);
}
```

 

## 2 调用方信息

在 .Net Framework 4.5 中引入了三个 Attribute：CallerMemberName、CallerFilePath 和 CallerLineNumber。在编译器的配合下，分别可以获取到调用函数（准确讲应该是成员）名称，调用文件及调用行号。上面的 TraceMessage 函数可以实现如下：

 

```
public void DoProcessing()
{
  TraceMessage("Something happened.");
}
 
public void TraceMessage(string message,
  [CallerMemberName] string memberName = "",
  [CallerFilePath] string sourceFilePath = "",
  [CallerLineNumber] int sourceLineNumber = 0)
  {
    Trace.WriteLine("message: " + message);
    Trace.WriteLine("member name: " + memberName);
    Trace.WriteLine("source file path: " + sourceFilePath);
    Trace.WriteLine("source line number: " + sourceLineNumber);
  }
```

 

另外，在构造函数，析构函数、属性等特殊的地方调用 CallerMemberName 属性所标记的函数时，获取的值有所不同，其取值如下表所示：

| 调用的地方             | CallerMemberName  获取的结果        |
| ---------------------- | ----------------------------------- |
| 方法、属性或事件       | 方法，属性或事件的名称              |
| 构造函数               | 字符串“.ctor”                       |
| 静态构造函数           | 字符串“.cctor”                      |
| 析构函数               | 字符串“Finalize”                    |
| 用户定义的运算符或转换 | 生成的名称成员。例如：“op_Addition” |
| 特性构造函数           | 特性所应用的成员的名称              |

注：对于在属性中调用 CallerMemberName 所标记的函数即可获取属性名称，通过这种方式可以简化 INotifyPropertyChanged 接口的实现。

 

# **C# 6.0**

## 1 自动属性增强

1.1 自动属性初始化（Initializers for auto-properties）

 

```
public string Test { get; set; } = "Hello Librame";
```

 

1.2 只读属性初始化（Getter-only auto-properties）

 

```
public string Test { get; } = "Hello Librame";
 
```

## 2 表达式函数成员集合（Expession bodied function members）

```
2.1 用 Lambda 作为函数体（Expression bodies on method-like members）
 
public void Print() => Console.WriteLine(string.Empty);
 
2.2 用 Lambda 作为属性（Expression bodies on property-like function members）
 
public string Test => "Hello Librame";
 
```

## 3 引用静态类（Using Static）

```
在 using 中可c以指定一个静态类，然后可以在随后的代码中直接使用静态的成员。
 
using System.Math;
…
static void Main(string[] args)
{
  Console.WriteLine(Sqrt(1*2)); // Math.Sqrt();
}
 
```

## 4 空值判断（Null-conditional operators）

```
 
static void Main(string[] args)
{
  var str = args?[0];
}
 
```

## 5 字符串嵌入值

```
 
public void Add(string name)
{
  Console.WriteLine($"Add {name}"); // 单行
  
  var str = $@"Add
{name}s"; // 多行
  Console.WriteLine(str);
}
 
```

## 6 nameof 表达式（nameof expressions）

```
 
public void Add(string name)
{
  if (name == null) throw new ArgumentNullException(nameof(name));
}
 
```

## 7 带索引的对象初始化器（Index initializers）

```
 
var numbers = new Dictionary<int, string> { [7] = "seven", [9] = "nine" };
 
```

## 8 异常过滤器（Exception filters）

```
允许在 catch 中应用一个条件。
 
try
{
  //…
}
catch (WebException wex) when (wex.Status == WebExceptionStatus.Timeout)
{
  //…
}
 
```

## 9 catch 和 finally 中的 await（Await in catch and finally blocks）

在 C#5.0 中，await 关键字是不能出现在 catch 和 finnaly 块中的。而在 C#6.0 中：

 

```
try
{
  res = await Resource.OpenAsync(…); // You could do this. … 
}
catch (ResourceException e)
{
  await Resource.LogAsync(res, e); // Now you can do this … 
}
finally
{
  if (res != null) await res.CloseAsync(); // … and this. 
}
 
```

## 10 无参数的结构体构造函数（Parameterless constructors in structs）

```
 
struct Person
{
  public Person()
    : this(10)
  {
  }
  public Person(int age)
  {
    Age = age;
  }
 
  public int Age { get; }
}
 
static void Main(string[] args)
{
  var p1 = new Person(); // p1.Age = 10
  var p2 = default(Person); // p2.Age = 0
}
 
```

# **C# 7.0**

## 1 接收或丢弃 out 变量（out variables and discards）

```
 
var p = new Point();
p.GetCoordinates(out int x, out int y); // 接收 out x 和 y 变量
p.GetCoordinates(out int x, out _); // 接收 out x 变量，丢弃后一个变量
 
```

## 2 元组（Tuples）

```
 
var tuple = { A: 10, B: "123" };
Console.WriteLine($"a: {tuple.A}, b: {tuple.B}");
 
方法返回元组：
 
static (int A, string B) GetFunc()
{
  return (10, "123");
}
 
解构类：
 
public class Student
{
  public Student(int age, string name)
  {
    Age = age;
    Name = name;
  }
 
  public int Age { get; set; }
  public string Name { get; set; }
 
  public void Deconstruct(out int age, out string name)
  {
    age = Age;
    name = Name;
  }
}
 
var (Age, Name) = new Student(18, "Librame"); // 使用解构
 
```

## 3 匹配模式（Pattern Matching）

```
3.1 参数转化为类型变量
 
if (obj is string str) Console.WriteLine(str);
 
3.2 扩展 Switch 语句
 
switch (obj)
{
  case Point p:
    break;
  case int i:
    break;
  case string b when b == "123":
    break;
}
 
```

## 4 局部变量和引用返回（ref locals and returns）

```
 
static void Main(string[] args)
{
  var numbers = { 0, 1, 2, 3 };
  ref int numRef = ref numbers[3];
  Console.WriteLine(numRef);
}
 
注：ref locals 必须是数组中的一个元素、类中的字段（不能是属性）、或者本地变量。通常与 ref returns 一起使用。
 
```

## 5 局部函数（Local Functions）

```
 
static void Main(string[] args)
{
  string GetString()
  {
    return string.Empty;
  }
 
  Console.WriteLine(GetString());
}
 
```

## 6 更多的函数成员表达式体（More expression-bodied members）

```
 
public class Student
{
  private string _name;
 
  public Student(string name) => _name = name; // 构造函数表达式
 
  ~Student() => Console.WriteLine("Finalized!"); // 析构函数表达式
 
  public string Name
  {
    get => _name;
    set => _name = value ?? "Librame"; // 设置属性表达式
  }
 
  public string this[string name] => _name; // 索引器表达式（C# 6.0 已提供支持）
}
 
```

## 7 异常表达式（throw Exceptions）

```
throw 可以做为个表达式出现在一个函数体中，而且也可以出现在三元表达式中。
 
static string Capitalize(string value)
{
  return value == null ? Throw new ArgumentNullException(nameof(value)) :
    value == "" ? string.Empty :
    char.ToUpper(value[0]) + value.Substring(1);
}
 
```

## 8 扩展异步返回类型（Generalized async return types）

```
C# 7.0 新增了 ValueTask<T> 异步类型。
 
async ValueTask<int> Func()
{
  await Task.Delay(3000);
  return 100;
}
 
```

## 9 数值文字语法改进（Numberic literal syntax improvements）

```
C# 7.0 允许在数字文字中_作为数字分隔符出现：
 
var d = 123_456;
var x = 0xAB_CD_EF;
 
另外，C# 7.0 引入了二进制文字，因此您可以直接指定位模式，而不必知道十六进制符号。
 
var b = 0b1010_1011_1100_1101_1110_1111;
 
注：二进制文字需用0b前缀指定。
 
```

# **C# 7.1**

## 1 异步入口函数（Async Main）

```
 
static async void Main(string[] args)
{
  //…
}
 
```

## 2 默认值表达式（Default Expressions）

```
 
int i = defaullt;
object obj = default;
DateTime dt = default;
T inst = default;
 
```

## 3 推断元组名称（Infer tuple names）

```
 
var p = new Point();
var t1 = { X: p.X, Y: p.Y }; // 显示命名
var t2 = { p.X, p.Y }; // 推断名称
 
```

## 4 泛型模式匹配（Pattern-matching with generics）

```
C# 7.0 中最重要的新功能之一是使用 is 关键字和 switch 语句进行模式匹配。类型模式允许我们根据值类型进行分支：
 
void Eat(IAnimal animal)
{
  switch (animal)
  {
    case Dog dog:
      break;
    case Cat cat:
      break;
  }
}
 
此版本扩展了泛型支持：
 
void Eat<T>(T animal) where T : IAnimal
{
  switch (animal)
  {
    case Dog dog:
      break;
    case Cat cat:
      break;
  }
}
 
```

# **C# 7.2**

## 1 只读引用（ref readonly）

```
 
static Vector3 Normalize(ref readonly Vector3 value)
{
  // 从指定的向量返回一个新的单位向量
  // 签名确保不能修改输入向量
}
 
2 interior pointer/Span/ref struct
 
```

## 3 非尾随命名参数（non-trailing named arguments）

```
 
```

WriteText("Hello world", true, true);

WriteText("Hello world", bold: true, centered: true);

WriteText("Hello world", centered: true, bold: true); // 不同顺序

```
WriteText("Hello world", bold: true, true); // 新增
 
```

## 4 私有保护（private protected）

```
表示成员只能在同一个程序集中对子类可见。
 
```

## 5 条件参考运算符（conditional ref operator）

```
 
ref var firstItem = ref(emptyArray.Length > 0 ? ref emptyArray[0] : ref nonEmptyArray[0]);
 
```

## 6 基本说明符后的数字分隔符（Digit separator after base specifier）

```
在 C# 7.0 中，允许在数字文字中使用分隔符以提高可读性：
 
```

var hex = 0xff_ff_ff;

var bin = 0b0000_1111;

```
 
此版支持基本说明符之后允许分隔符：
 
```

var hex = 0x_ff_ff_ff;

var bin = 0b_0000_1111;

```
 
7 Tiebreaker for by-val and in overloads
 
8 ref and this ordering in ref extension
 
 
```

# **C# 7.3**

```
1 blittable
 
2 Support == and != for tuples
 
3 strongname
 
4 Attribute on backing field
 
5 Ref Reassignment
 
6 Constraints
 
7 Stackalloc initializers
 
8 Custom fixed
 
9 Indexing movable fixed buffers
 
10 Improved overload candidates
 
11 Expression variables
 
 
```

# **C# 8.0**

```
1 Default Interface Methods
 
2 Nullable reference type
 
3 Recursive patterns
 
4 Async streams
 
5 Caller expression attribute
 
6 Target-typed new
 
7 Enhanced using
 
8 Generic attributes
 
9 Ranges
 
10 Default in deconstruction
 
11 Relax ordering of ref and partial modifiers
 
12 Null-coalescing Assignment
 
13 Alternative interpolated verbatim strings
 
14 stackalloc in nested contexts
 
15 Unmanaged generic structs
 
16 Static local functions
 
17 Readonly members
```