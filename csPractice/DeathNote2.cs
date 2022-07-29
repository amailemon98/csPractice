/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPractice
{
    class DeathNote2
    {
    }
}
*/

class Person
{
    public string name;    //퍼블릭 변수 연습용
    private int age;       //프라이빗 변수 연습용  => 아 클래스안에있어서 필드구나 어쨋든
    private bool isAlive;

    public Person(string _name, int _age) //클래스이름과 같은 함수는 생성자! => 함수가아니라 메소드구나? 어쨋든
    {                                     //생성자는 리턴형식이없음!! 클래스생성할때 만들어지는거라~
        isAlive = true;
        name = _name;
        age = _age;   //프라이빗이지만 같은클래스안에있어서 선언이 가능함
    }

    public int AgeSet                   //프라이빗변수를 밖에서도 쓰기위해 만든 함수
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public int getage()
    {
        return this.age;
    }
    public void setage(int _age)
    {
        this.age = _age;
    }

    //사용시
    void Main()
    {
        AgeSet = 30;
        MessageBox.Show(AgeSet.ToString());

        setage(30);
        MessageBox.Show(getage().ToString());
    }

    public void Go(string sender) //놀러가는함수!
    {
        MessageBox.Show(name + " Go to " + sender);//메세지박스는 c# winform에서 지원하는 객체니까 그냥 print랑 같은거라 생각하면됨
    }
    public void Eat(string sender) //뭐 먹는함수!
    {
        MessageBox.Show(name + " Eat " + sender);
    }
    public void Die()   //죽는함수!
    {
        isAlive = false;
    }

}
class Food
{
    private string name;
    public Food(string _name)
    {
        name = _name;
    }
    public string Foodname
    {
        get { return "while eating a" + this.name; }
        set { this.name = value; }
    }
}
class Place
{
    private string name;
    public Place(string _name)
    {
        name = _name;
    }
    public string Placename
    {
        get { return "while visiting a " + this.name; }
        set { this.name = value; }
    }
}

class DeathNote
{
    private Person owner;
    private string name;
    private string Why = "Heart Attack";  //사인 기본값은 심장마비

    public DeathNote(Person _owner, string _name)
    {
        owner = _owner;
        name = _name;
    }
    public void Setowner(Person _owner)
    {
        owner = _owner;
    }
    public void WriteName(Person _person)  //데스노트에 이름을 적는함수 이름만적힐때
    {
        string Explanation = string.Empty;
        _person.Die();
        Explanation = "He is Dead.. His Name is" + _person.name + "\r\n";
        Explanation += "He Died at the Age of " + _person.AgeSet + "\r\n";
        Explanation += "His cause of death is a" + Why + "\r\n";
    }
    public void WriteName(Person _person, string _Why)  //이름과 사인이 적힐때
    {
        Why = _Why;
        string Explanation = string.Empty;
        _person.Die();
        Explanation = "He is Dead.. His Name is" + _person.name + "\r\n";
        Explanation += "He Died at the Age of " + _person.AgeSet + "\r\n";
        Explanation += "His cause of death is a" + Why + "\r\n";
    }
    public void WriteName(Person _person, string _Why, Food _food)  //이름과 사인과 음식이적힐때
    {
        Why = _Why;
        string Explanation = string.Empty;
        _person.Die();
        Explanation = "He is Dead.. His Name is" + _person.name + "\r\n";
        Explanation += "He Died at the Age of " + _person.AgeSet + "\r\n";
        Explanation += "His cause of death is a" + Why + " " + _food.Foodname + "\r\n";
    }
    public override void WriteName(Person _person, string _Why, Place _place)  //음식과 사인과 장소가적힐때 
    {
        Why = _Why;
        string Explanation = string.Empty;
        _person.Die();
        Explanation = "He is Dead.. His Name is" + _person.name + "\r\n";
        Explanation += "He Died at the Age of " + _person.AgeSet + "\r\n";
        Explanation += "His cause of death is a" + Why + " " + _place.Placename + "\r\n";
    }
}

void Start()
{
    Person 행인1번 = new Person("김민수", 32);
    Person 행인2번 = new Person("이현승", 30);
    Person 행인3번 = new Person("팽호식", 38);
    Person 행인4번 = new Person("신승민", 42);
    List<Person> 행인리스트 = new List<Person>();
    행인리스트.Add(new Person("김영수", 30));
    행인리스트.Add(new Person("김영희", 29));
    행인리스트.Add(new Person("장철수", 32));
    행인리스트.Add(new Person("박희영", 31));
    행인리스트.Add(new Person("이민영", 24));
    행인리스트.Add(new Person("홍길동", 28));
    행인리스트.Add(new Person("더이상", 26));
    행인리스트.Add(new Person("이름이", 29));
    행인리스트.Add(new Person("생각이", 27));
    행인리스트.Add(new Person("안난다", 30));

    DeathNote note1 = new DeathNote(행인1번, "류크의노트");
    DeathNote note2 = new DeathNote(행인리스트[0], "선제의노트");

    note1.WriteName(행인2번);
    note1.WriteName(행인리스트[3], "배고파서");
    note1.WriteName(행인4번);
    note2.WriteName(행인리스트[5], "배불러서", new Food("빵"));
    note2.WriteName(행인1번, "과로", new Place("회사"));
    note1.Setowner(행인리스트[9]);
    note2.WriteName(행인리스트[2], "더워서", new Place("놀이동산"));
    note2.WriteName(행인리스트[8], "매워서", new Food("불닭볶음면"));
}