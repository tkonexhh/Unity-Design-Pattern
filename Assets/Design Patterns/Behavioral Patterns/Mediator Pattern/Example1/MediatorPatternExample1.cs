using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Mediator
{
    public class MediatorPatternExample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // Create chatroom
            ChatRoom chatroom = new ChatRoom();

            // Create participants and register them
            Person George = new Person("George", chatroom);
            Person Paul = new Person("Paul", chatroom);
            Person Ringo = new Person("Ringo", chatroom);
            Person John = new Person("John", chatroom);
            Person Yoko = new Person("Yoko", chatroom);

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            George.Send("John", "Hi");
            John.Send("George", "HI!");
            Yoko.Send("Paul", "How are you?");
        }

    }

    class Person
    {
        private string name;
        private ChatRoom chatRoom;
        public string Name => name;

        public Person(string name, ChatRoom chatRoom)
        {
            this.name = name;
            this.chatRoom = chatRoom;
        }

        public void Send(string to, string message)
        {
            chatRoom.Send(name, to, message);
        }

        public void Receive(string message)
        {
            Debug.LogError(message);
        }
    }

    abstract class AbstractChatRoom
    {
        public abstract void Register(Person person);
        public abstract void Send(string from, string to, string msg);
    }


    class ChatRoom : AbstractChatRoom
    {
        private Dictionary<string, Person> personMap = new Dictionary<string, Person>();

        public override void Register(Person person)
        {
            if (!personMap.ContainsKey(person.Name))
            {
                personMap.Add(person.Name, person);
            }
        }

        public override void Send(string from, string to, string msg)
        {
            var pserson_From = personMap[from];
            var pserson_To = personMap[to];
            if (pserson_From != null && pserson_To != null)
            {
                pserson_To.Receive(msg);
            }
        }
    }

}