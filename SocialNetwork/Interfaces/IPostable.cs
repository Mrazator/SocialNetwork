using System;

namespace SocialNetwork.Interfaces
{
    internal interface IPostable
    {
        int Id { get; set; }
        DateTime PostedAt { get; set; }
        string Text { get; set; }

        //post as an anonymous ? true : false
        bool StayAnonymous { get; set; }
    }
}