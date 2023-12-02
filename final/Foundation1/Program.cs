using System;
using System.Net;
using System.Reflection;
using System.Reflection.PortableExecutable;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video { _title = "Funny Cats", _author = "CatLover22", _lengthInSeconds = 111 };
        video1.AddComment("AnimalRescue45", "Cute cat video!");
        video1.AddComment("PawsWithClaws", "This made me happy.");
        video1.AddComment("Cats4Life", "This brightened my day!");
        videos.Add(video1);

        Video video2 = new Video { _title = "Car Races", _author = "Need4Speed", _lengthInSeconds = 222 };
        video2.AddComment("HomeGarageGuy", "Is that a new world record?");
        video2.AddComment("WrenchHead", "I wish we had a track like that here");
        video2.AddComment("MechanicV8", "Nice work on the custom build.");
        videos.Add(video2);

        Video video3 = new Video { _title = "DIY Home Remodel", _author = "CraftyHome", _lengthInSeconds = 333 };
        video3.AddComment("CraftyKaren", "How much is lumber in your area?");
        video3.AddComment("FlipThisHouse", "Nice work on the front porch!");
        video3.AddComment("HappyHouse", "This house is beautiful.");
        video3.AddComment("BobTheBuilder", "I can do better work.");
        videos.Add(video3);
        
        Video video4 = new Video { _title = "5 Thing You Should Know About Programming", _author = "HelloWorld", _lengthInSeconds = 444 };
        video4.AddComment("SiliconValley", "Why did you write your code like that?");
        video4.AddComment("Code4Noobs", "This video is very informative!");
        video4.AddComment("CodeCrazy45", "I will use this technique.");
        video4.AddComment("ProgramBuzz", "Thanks for sharing this video!");
        videos.Add(video4);

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}