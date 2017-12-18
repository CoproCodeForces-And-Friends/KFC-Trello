using System;

namespace KFCTrello.Models
{
    public class WebhookModel
    {
        public Action Action { get; set; }
    }

    public class Action
    {
        public string Id { get; set;}
        public string IdMemberCreator { get; set; }
        public Data Data { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public MemberCreator MemberCreator { get; set; }    
    }

    public class Data
    {
        public Board Board { get; set; }
        public Card Card { get; set; }
        public bool Voted { get; set;  }
    }

    public class Board
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

    public class Card
    {
        public int IdShort { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }
    
    public class MemberCreator
    {
        public string Id { get; set; }
        public string AvatarHash { get; set; }
        public string FullName { get; set; }
        public string Initials { get; set; }
        public string Username { get; set; }
    }
}