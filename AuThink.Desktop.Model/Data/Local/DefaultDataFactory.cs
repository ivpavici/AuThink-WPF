using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AuThink.Desktop.Core;

using ent = AuThink.Desktop.Core.Entities;

namespace AuThink.Desktop.Model.Data.Local
{
    public class DefaultDataFactory : IDataProvider
    {
        public IEnumerable<ent::Test> GetAll()
        {
            return AuThink.Desktop.Model.Properties.Settings.Default.Setting == "Hr"
              ? PrivateDataModel_Hr()
              : PrivateDataModel_En();
        }

        public IEnumerable<ent::Child> GetAllChildren()
        {
            throw new System.NotImplementedException();
        }

        private static IEnumerable<ent::Test> PrivateDataModel_Hr()
        {
            return
                new[]
                    {
                        new ent::Test
                        (
                        id:          2,
                        name:        "Nastavi niz",
                        description: "U ovom testu je potrebno kroz tri zadatka prepoznati koji predmeti nastavljaju zadani niz.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          4,
                                   name:        "Nastavi niz, Težina 1",
                                   description: "U ovom zadatku treba nastaviti niz od dva ponuđena predmeta. Zadatak se rješava klikom na ispravan predmet u okomitom nizu predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-continue-sequence-256x256.png"),
                                   type:        "#004",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                     new ent::Picture.AnswerPicture(21, @"Resources/Images/ContinueSequence/1/bowl.png",     null, false),
                                                     new ent::Picture.AnswerPicture(22, @"Resources/Images/ContinueSequence/1/casserole.png",null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/nastavi_niz.mp3"), "title")
                                  ),
                                  new ent::Task
                                   (
                                   id:          5,
                                   name:        "Nastavi niz, Težina 2",
                                   description: "U ovom zadatku treba nastaviti niz od tri ponuđena predmeta. Zadatak se rješava klikom na ispravan predmet u okomitom nizu predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-continue-sequence-256x256.png"),
                                   type:        "#004",
                                   difficulty:   2,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                     new ent::Picture.AnswerPicture(23, @"Resources/Images/ContinueSequence/2/coffee cup.png", null, false),
                                                     new ent::Picture.AnswerPicture(24, @"Resources/Images/ContinueSequence/2/cup.png",        null, false),
                                                     new ent::Picture.AnswerPicture(25, @"Resources/Images/ContinueSequence/2/frying pan.png", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/nastavi_niz.mp3"), "title")
                                  ),
                                  new ent::Task
                                   (
                                   id:          6,
                                   name:        "Nastavi niz, Težina 3",
                                   description: "U ovom zadatku treba nastaviti niz od četiri ponuđena predmeta. Zadatak se rješava klikom na ispravan predmet u okomitom nizu predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-continue-sequence-256x256.png"),
                                   type:        "#004",
                                   difficulty:   3,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                     new ent::Picture.AnswerPicture(26, @"Resources/Images/ContinueSequence/3/full.png",          null, false),
                                                     new ent::Picture.AnswerPicture(27, @"Resources/Images/ContinueSequence/3/jug.png",           null, false),
                                                     new ent::Picture.AnswerPicture(28, @"Resources/Images/ContinueSequence/3/kitchen chair.png", null, false),
                                                     new ent::Picture.AnswerPicture(29, @"Resources/Images/ContinueSequence/3/glass.png",         null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/nastavi_niz.mp3"), "title")
                                  ),
                               }),
                        new ent::Test
                        (
                        id:          3,
                        name:        "Prepoznaj boju kojom je obojen predmet",
                        description: "U ovom testu je potrebno kroz tri zadatka prepoznati kojom su bojom obojani zadani predmeti iz kuhinje.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          7,
                                   name:        "Prepoznaj boju kojom je obojen predmet, Težina 1",
                                   description: "U ovom zadatku treba pogoditi kojom je bojom obojan dani predmet. U zadatku se nalazi šest predmeta sa po dvije moguće boje.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-colors-256x256.png"),
                                   type:        "#003",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.ColorPicture>
                                                {
                                                    new ent::Picture.ColorPicture(30, @"Resources/Images/DetectColors/1/bowl.png",               null, new List<ent::Color>{new ent::Color(1, "#0000FF", true, 28),new ent::Color(1, "#FF0000", false, 28)}),
                                                    new ent::Picture.ColorPicture(31, @"Resources/Images/DetectColors/1/red-casserole.png",      null, new List<ent::Color>{new ent::Color(1, "#FF0000", true, 28),new ent::Color(1, "#A52A2A", false, 29)}),
                                                    new ent::Picture.ColorPicture(32, @"Resources/Images/DetectColors/1/blue coffee cup.png",    null, new List<ent::Color>{new ent::Color(1, "#0000FF", true, 28),new ent::Color(1, "#800080", false, 30)}),
                                                    new ent::Picture.ColorPicture(33, @"Resources/Images/DetectColors/1/greenCup.png",           null, new List<ent::Color>{new ent::Color(1, "#008000", true, 28),new ent::Color(1, "#FFA500", false, 31)}),
                                                    new ent::Picture.ColorPicture(34, @"Resources/Images/DetectColors/1/red glass.png",          null, new List<ent::Color>{new ent::Color(1, "#FF0000", true, 28),new ent::Color(1, "#008000", false, 32)}),
                                                    new ent::Picture.ColorPicture(35, @"Resources/Images/DetectColors/1/green kitchen chair.png",null, new List<ent::Color>{new ent::Color(1, "#008000", true, 28),new ent::Color(1, "#0000FF", false, 33)})
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/koje_boje1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          8,
                                   name:        "Prepoznaj boju kojom je obojen predmet, Težina 2",
                                   description: "U ovom zadatku treba pogoditi kojom je bojom obojan dani predmet. U zadatku se nalazi četiri predmeta sa po četiri moguće boje.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-colors-256x256.png"),
                                   type:        "#003",
                                   difficulty:   2,
                                   pictures:new List<ent::Picture.ColorPicture>
                                                {
                                                    new ent::Picture.ColorPicture(36, @"Resources/Images/DetectColors/2/bowl.png",                 null, new List<ent::Color>{new ent::Color(1, "#0000FF", true, 28),new ent::Color(1, "#008000", false, 34),new ent::Color(1, "#A52A2A", false, 28),new ent::Color(1, "#FFA500", false, 34)}),
                                                    new ent::Picture.ColorPicture(37, @"Resources/Images/DetectColors/2/greenCup.png",             null, new List<ent::Color>{new ent::Color(1, "#008000", true, 28),new ent::Color(1, "#FFA500", false, 35),new ent::Color(1, "#0000FF", false, 28),new ent::Color(1, "#A52A2A", false, 35)}),
                                                    new ent::Picture.ColorPicture(38, @"Resources/Images/DetectColors/2/red kitchen chair.png",    null, new List<ent::Color>{new ent::Color(1, "#FF0000", true, 28),new ent::Color(1, "#008000", false, 36),new ent::Color(1, "#FFA500", false, 28),new ent::Color(1, "#0000FF", false, 36)}),
                                                    new ent::Picture.ColorPicture(39, @"Resources/Images/DetectColors/2/yellow kitchen tool_3.png",null, new List<ent::Color>{new ent::Color(1, "#FFFF00", true, 28),new ent::Color(1, "#0000FF", false, 37),new ent::Color(1, "#FFA500", false, 28),new ent::Color(1, "#008000", false, 37)})
                                                }                                                                                                    ,
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/koje_boje1.mp3"), "title")                                                                                                                
                                   ),
                                   new ent::Task
                                   (
                                   id:          9,
                                   name:        "Prepoznaj boju kojom je obojen predmet, Težina 3",
                                   description: "U ovom zadatku treba pogoditi kojom je bojom obojan dani predmet. U zadatku se nalazi dva predmeta sa po šest mogućih boja.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-colors-256x256.png"),
                                   type:        "#003",
                                   difficulty:   2,
                                   pictures:new List<ent::Picture.ColorPicture>
                                                {
                                                    new ent::Picture.ColorPicture(40, @"Resources/Images/DetectColors/3/red kitchen chair.png",null, new List<ent::Color>{new ent::Color(1, "#FF0000", true, 28),new ent::Color(1, "#008000", false, 34),new ent::Color(1, "#FFA500", false, 28),new ent::Color(1, "#0000FF", false, 34),new ent::Color(1, "#A52A2A", false, 34),new ent::Color(1, "#FFFF00", false, 34)}),
                                                    new ent::Picture.ColorPicture(41, @"Resources/Images/DetectColors/3/greenCup.png",         null, new List<ent::Color>{new ent::Color(1, "#008000", true, 28),new ent::Color(1, "#FF0000", false, 35),new ent::Color(1, "#0000FF", false, 28),new ent::Color(1, "#FFA500", false, 35),new ent::Color(1, "#FFFF00", false, 35),new ent::Color(1, "#A52A2A", false, 35)})
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/koje_boje1.mp3"), "title")
                                   )}),
                        new ent::Test
                        (
                        id:          4,
                        name:        "Prepoznaj različit predmet",
                        description: "U ovom testu je potrebno kroz tri zadatka prepoznati različite predmete iz niza istih predmeta.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          10,
                                   name:        "Prepoznaj različit predmet, Težina 1",
                                   description: "U ovom zadatku je potrebno kroz četiri reda predmeta prepoznati koji je među njima različit.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-different-items-256x256.png"),
                                   type:        "#002",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(42, "Resources/Images/DetectDifferentItems/1/bowl.png",           null, true),
                                                    new ent::Picture.AnswerPicture(43, "Resources/Images/DetectDifferentItems/1/casserole.png",      null, false),
                                                    new ent::Picture.AnswerPicture(44, "Resources/Images/DetectDifferentItems/1/frying pan.png",     null, false),
                                                    new ent::Picture.AnswerPicture(45, "Resources/Images/DetectDifferentItems/1/glass.png",          null, false),
                                                    new ent::Picture.AnswerPicture(46, "Resources/Images/DetectDifferentItems/1/kitchen tool_2.png", null, false),
                                                    new ent::Picture.AnswerPicture(47, "Resources/Images/DetectDifferentItems/1/plate_1.png",        null, false)
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/pronadji_razliciti1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          11,
                                   name:        "Prepoznaj različit predmet, Težina 2",
                                   description: "U ovom zadatku je potrebno prepoznati predmet koji je u cijelosti različit od preostalih, razbacanih predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-different-items-256x256.png"),
                                   type:        "#002",
                                   difficulty:   2,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(48, "Resources/Images/DetectDifferentItems/2/lonac.png",            null, true ),
                                                    new ent::Picture.AnswerPicture(49, "Resources/Images/DetectDifferentItems/2/Red_cambridge_mug.png", null, false),
                                                    
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/pronadji_razliciti1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          12,
                                   name:        "Prepoznaj različit predmet, Težina 3",
                                   description: "U ovom zadatku je potrebno prepoznati predmet koji je različit, ali jako sličan preostalim, razbacanim predmetima.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-different-items-256x256.png"),
                                   type:        "#002",
                                   difficulty:   3,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(50, "Resources/Images/DetectDifferentItems/3/individual-red-mug.png", null, true ),
                                                    new ent::Picture.AnswerPicture(51, "Resources/Images/DetectDifferentItems/3/Red_cambridge_mug.png",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/pronadji_razliciti1.mp3"), "title")
                                   )}),
                        new ent::Test
                        (
                        id:          6,
                        name:        "Upari polovice",
                        description: "U ovom testu je potrebno kroz tri zadatka prepoznati i spojiti polovice svakom pojedinom predmetu.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          16,
                                   name:        "Upari polovice, Težina 1",
                                   description: "U ovom zadatku treba upariti polovice za dva zadana predmeta. Potrebno je povući polovice iz donje liste do točnog predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-halves-256x256.png"),
                                   type:        "#005",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.BasicDetails>
                                                {
                                                   new ent::Picture.BasicDetails(67, @"Resources/Images/PairHalfs/1/bowl.png"),
                                                   new ent::Picture.BasicDetails(68, @"Resources/Images/PairHalfs/1/casserole.png"),
                                                   new ent::Picture.BasicDetails(69, @"Resources/Images/PairHalfs/1/plate_1.png"),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/pronadji_polovina1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          17,
                                   name:        "Upari polovice, Težina 2",
                                   description: "U ovom zadatku treba upariti polovice za pet zadanih predmeta. Potrebno je povući polovice iz donje liste do točnog predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-halves-256x256.png"),
                                   type:        "#005",
                                   difficulty:   2,
                                   pictures:new List<ent::Picture.BasicDetails>
                                                {
                                                   new ent::Picture.BasicDetails(67, @"Resources/Images/PairHalfs/2/bowl.png"),
                                                   new ent::Picture.BasicDetails(68, @"Resources/Images/PairHalfs/2/casserole.png"),
                                                   new ent::Picture.BasicDetails(69, @"Resources/Images/PairHalfs/2/coffee cup.png"),
                                                   new ent::Picture.BasicDetails(70, @"Resources/Images/PairHalfs/2/full.png"),
                                                   new ent::Picture.BasicDetails(71, @"Resources/Images/PairHalfs/2/jug.png"),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/pronadji_polovina1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          18,
                                   name:        "Upari polovice, Težina 3",
                                   description: "U ovom zadatku treba upariti polovice za sedam zadanih predmeta. Potrebno je povući polovice iz donje liste do točnog predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-halves-256x256.png"),
                                   type:        "#005",
                                   difficulty:   2,
                                   pictures:new List<ent::Picture.BasicDetails>
                                                {
                                                   new ent::Picture.BasicDetails(67, @"Resources/Images/PairHalfs/3/bowl.png"),
                                                   new ent::Picture.BasicDetails(68, @"Resources/Images/PairHalfs/3/casserole.png"),
                                                   new ent::Picture.BasicDetails(69, @"Resources/Images/PairHalfs/3/coffee cup.png"),
                                                   new ent::Picture.BasicDetails(70, @"Resources/Images/PairHalfs/3/full.png"),
                                                   new ent::Picture.BasicDetails(71, @"Resources/Images/PairHalfs/3/jug.png"),
                                                   new ent::Picture.BasicDetails(72, @"Resources/Images/PairHalfs/3/kitchen tool_2.png"),
                                                   new ent::Picture.BasicDetails(73, @"Resources/Images/PairHalfs/3/plate_1.png"),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/pronadji_polovina1.mp3"), "title")
                                   )}),
                        new ent::Test
                        (
                        id:          7,
                        name:        "Upari isti predmet",
                        description: "U ovom testu je potrebno kroz tri zadatka prepoznati i upariti dane predmete.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          19,
                                   name:        "Upari isti predmet, Težina 1",
                                   description: "U ovom zadatku treba upariti 3 zadana predmeta. Potrebno je povući predmet iz donje liste do točnog predmeta u gornjoj listi.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-same-items-256x256.png"),
                                   type:        "#001",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(95, @"Resources/Images/PairSameItems/1/kitchen tool_2.png", null, true),
                                                    new ent::Picture.AnswerPicture(96, @"Resources/Images/PairSameItems/1/kitchen tool_3.png", null, true),
                                                    new ent::Picture.AnswerPicture(97, @"Resources/Images/PairSameItems/1/kitchen tool_6.png", null, true),
                                                   
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/pronadji_isti1.mp3"), "title")
                                   ),
                                    new ent::Task
                                   (
                                   id:          20,
                                   name:        "Upari isti predmet, Težina 2",
                                   description: "U ovom zadatku treba upariti 5 zadanih predmeta. Potrebno je povući predmet iz donje liste do točnog predmeta u gornjoj listi.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-same-items-256x256.png"),
                                   type:        "#001",
                                   difficulty:   2,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(98, @"Resources/Images/PairSameItems/2/bowl.png",           null, true),
                                                    new ent::Picture.AnswerPicture(99, @"Resources/Images/PairSameItems/2/casserole.png",      null, true),
                                                    new ent::Picture.AnswerPicture(100, @"Resources/Images/PairSameItems/2/cup.png",           null, true),
                                                    new ent::Picture.AnswerPicture(101, @"Resources/Images/PairSameItems/2/kitchen chair.png", null, true),
                                                    new ent::Picture.AnswerPicture(102, @"Resources/Images/PairSameItems/2/frying pan.png",    null, true)
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/pronadji_isti1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          21,
                                   name:        "Upari isti predmet, Težina 3",
                                   description: "U ovom zadatku treba upariti 7 zadanih predmeta. Potrebno je povući predmet iz donje liste do točnog predmeta u gornjoj listi.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-same-items-256x256.png"),
                                   type:        "#001",
                                   difficulty:   3,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(101, @"Resources/Images/PairSameItems/3/17622157-orange-juice-in-a-jug.png", null, true),
                                                    new ent::Picture.AnswerPicture(102, @"Resources/Images/PairSameItems/3/693024_1.png",                       null, true),
                                                    new ent::Picture.AnswerPicture(103, @"Resources/Images/PairSameItems/3/9620-08240.png",                     null, true),
                                                    new ent::Picture.AnswerPicture(104, @"Resources/Images/PairSameItems/3/casa1.png",                          null, true),
                                                    new ent::Picture.AnswerPicture(105, @"Resources/Images/PairSameItems/3/kitchen-tool_2.png",                 null, true),
                                                    new ent::Picture.AnswerPicture(106, @"Resources/Images/PairSameItems/3/plate_1.png",                        null, true)
                                                    
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/pronadji_isti1.mp3"), "title")
                                   )
                               }),
                        new ent::Test
                        (
                        id:          8,
                        name:        "Poredaj po veličini",
                        description: "U ovom testu je potrebno kroz tri zadatka posložiti zadane predmete po veličini.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          22,
                                   name:        "Poredaj po veličini, Težina 1",
                                   description: "U ovom zadatku treba posložiti tri predmeta po veličini. Klikom na točan predmet se stvara na gornjoj listi.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-order-by-size-256x256.png"),
                                   type:        "#008",
                                   difficulty:   3,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(107, @"Resources/Images/SortBySize/1/jug-1.png", null, true),
                                                    new ent::Picture.AnswerPicture(108, @"Resources/Images/SortBySize/1/jug-2.png", null, true),
                                                    new ent::Picture.AnswerPicture(109, @"Resources/Images/SortBySize/1/jug-3.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/poredaj_po_velicini1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          23,
                                   name:        "Poredaj po veličini, Težina 2",
                                   description: "U ovom zadatku treba posložiti četiri predmeta po veličini. Klikom na točan predmet se stvara na gornjoj listi.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-order-by-size-256x256.png"),
                                   type:        "#008",
                                   difficulty:   5,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(110, @"Resources/Images/SortBySize/2/kitchen-tool_2-1.png", null, true),
                                                    new ent::Picture.AnswerPicture(111, @"Resources/Images/SortBySize/2/kitchen-tool_2-2.png", null, true),
                                                    new ent::Picture.AnswerPicture(112, @"Resources/Images/SortBySize/2/kitchen-tool_2-3.png", null, true),
                                                    new ent::Picture.AnswerPicture(113, @"Resources/Images/SortBySize/2/kitchen-tool_2-4.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/poredaj_po_velicini1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          24,
                                   name:        "Poredaj po veličini, Težina 3",
                                   description: "U ovom zadatku treba posložiti pet predmeta po veličini. Klikom na točan predmet se stvara na gornjoj listi.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-order-by-size-256x256.png"),
                                   type:        "#008",
                                   difficulty:   6,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(114, @"Resources/Images/SortBySize/3/cup-1.png", null, true),
                                                    new ent::Picture.AnswerPicture(115, @"Resources/Images/SortBySize/3/cup-2.png", null, true),
                                                    new ent::Picture.AnswerPicture(116, @"Resources/Images/SortBySize/3/cup-3.png", null, true),
                                                    new ent::Picture.AnswerPicture(117, @"Resources/Images/SortBySize/3/cup-4.png", null, true),
                                                    new ent::Picture.AnswerPicture(118, @"Resources/Images/SortBySize/3/cup-5.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/zadaci_upute/poredaj_po_velicini1.mp3"), "title")
                                   )
                               }),
                        new ent::Test
                        (
                        id:          9,
                        name:        "Pokaži predmet",
                        description: "U ovom testu je potrebno kroz niz zadataka pokazati na točan predmet prema glasovnoj uputi.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          25,
                                   name:        "Pokaži čašu",
                                   description: "U ovom zadatku treba pokazati čašu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_object/1/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_object/1/casa.jpg",   null, true),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_object/1/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_object/1/ubrus.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_casu1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          26,
                                   name:        "Pokaži bat",
                                   description: "U ovom zadatku treba pokazati bat u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   2,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_object/2/casa.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_object/2/bat.jpg",   null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_object/2/tava.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_object/2/ubrus.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_bat.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          27,
                                   name:        "Pokaži dasku",
                                   description: "U ovom zadatku treba pokazati dasku u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   3,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_object/3/bat.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_object/3/casa.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_object/3/tava.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_object/3/daska.jpg", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_dasku1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          28,
                                   name:        "Pokaži kuhinju",
                                   description: "U ovom zadatku treba pokazati kuhinju u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_object/4/bat.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_object/4/casa.jpg",      null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_object/4/kitchen41.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_object/4/daska.jpg",     null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_kuhinju.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          29,
                                   name:        "Pokaži lonac",
                                   description: "U ovom zadatku treba pokazati lonac u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(134, @"Resources/Images/VoiceCommands/Show_object/5/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(135, @"Resources/Images/VoiceCommands/Show_object/5/lonac.png",  null, true),
                                                    new ent::Picture.AnswerPicture(136, @"Resources/Images/VoiceCommands/Show_object/5/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(137, @"Resources/Images/VoiceCommands/Show_object/5/ubrus.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_lonac1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          30,
                                   name:        "Pokaži nož",
                                   description: "U ovom zadatku treba pokazati nož u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(138, @"Resources/Images/VoiceCommands/Show_object/6/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(139, @"Resources/Images/VoiceCommands/Show_object/6/noz.jpg",    null, true),
                                                    new ent::Picture.AnswerPicture(140, @"Resources/Images/VoiceCommands/Show_object/6/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(141, @"Resources/Images/VoiceCommands/Show_object/6/ubrus.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_noz.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          31,
                                   name:        "Pokaži šalicu",
                                   description: "U ovom zadatku treba pokazati šalicu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(142, @"Resources/Images/VoiceCommands/Show_object/7/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(143, @"Resources/Images/VoiceCommands/Show_object/7/salica.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(144, @"Resources/Images/VoiceCommands/Show_object/7/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(145, @"Resources/Images/VoiceCommands/Show_object/7/ubrus.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_salicu.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          32,
                                   name:        "Pokaži slavinu",
                                   description: "U ovom zadatku treba pokazati slavinu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(146, @"Resources/Images/VoiceCommands/Show_object/8/tanjur.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(147, @"Resources/Images/VoiceCommands/Show_object/8/slavina.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(148, @"Resources/Images/VoiceCommands/Show_object/8/casa.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(149, @"Resources/Images/VoiceCommands/Show_object/8/daska.jpg",   null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_slavinu.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          33,
                                   name:        "Pokaži sudoper",
                                   description: "U ovom zadatku treba pokazati sudoper u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(150, @"Resources/Images/VoiceCommands/Show_object/9/tanjur.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(151, @"Resources/Images/VoiceCommands/Show_object/9/sudoper.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(152, @"Resources/Images/VoiceCommands/Show_object/9/casa.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(153, @"Resources/Images/VoiceCommands/Show_object/9/daska.jpg",   null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_sudoper.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          34,
                                   name:        "Pokaži tanjur",
                                   description: "U ovom zadatku treba pokazati tanjur u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(154, @"Resources/Images/VoiceCommands/Show_object/10/slavina.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(155, @"Resources/Images/VoiceCommands/Show_object/10/tanjur.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(156, @"Resources/Images/VoiceCommands/Show_object/10/casa.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(157, @"Resources/Images/VoiceCommands/Show_object/10/daska.jpg",   null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_tanjur.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          35,
                                   name:        "Pokaži tavu",
                                   description: "U ovom zadatku treba pokazati tavu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(158, @"Resources/Images/VoiceCommands/Show_object/11/bat.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(159, @"Resources/Images/VoiceCommands/Show_object/11/tava.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(160, @"Resources/Images/VoiceCommands/Show_object/11/casa.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(161, @"Resources/Images/VoiceCommands/Show_object/11/ubrus.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_tavu1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          36,
                                   name:        "Pokaži ubrus",
                                   description: "U ovom zadatku treba pokazati ubrus u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(162, @"Resources/Images/VoiceCommands/Show_object/12/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(163, @"Resources/Images/VoiceCommands/Show_object/12/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(164, @"Resources/Images/VoiceCommands/Show_object/12/casa.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(165, @"Resources/Images/VoiceCommands/Show_object/12/ubrus.jpg",  null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_ubrus.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          37,
                                   name:        "Pokaži vilicu",
                                   description: "U ovom zadatku treba pokazati vilicu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(166, @"Resources/Images/VoiceCommands/Show_object/13/tanjur.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(167, @"Resources/Images/VoiceCommands/Show_object/13/zuti_tanjur.jpeg", null, false),
                                                    new ent::Picture.AnswerPicture(168, @"Resources/Images/VoiceCommands/Show_object/13/ubrus2.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(169, @"Resources/Images/VoiceCommands/Show_object/13/fork.png",         null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_vilicu.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          38,
                                   name:        "Pokaži vrč",
                                   description: "U ovom zadatku treba pokazati vrč u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(170, @"Resources/Images/VoiceCommands/Show_object/14/noz.jpg",           null, false),
                                                    new ent::Picture.AnswerPicture(171, @"Resources/Images/VoiceCommands/Show_object/14/duboki_tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(172, @"Resources/Images/VoiceCommands/Show_object/14/vrč.jpg",           null, true),
                                                    new ent::Picture.AnswerPicture(173, @"Resources/Images/VoiceCommands/Show_object/14/zlica.jpg",         null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_vrc.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          39,
                                   name:        "Pokaži žlicu",
                                   description: "U ovom zadatku treba pokazati žlicu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(174, @"Resources/Images/VoiceCommands/Show_object/15/slavina.jpg",         null, false),
                                                    new ent::Picture.AnswerPicture(175, @"Resources/Images/VoiceCommands/Show_object/15/tanjur.jpg",          null, false),
                                                    new ent::Picture.AnswerPicture(176, @"Resources/Images/VoiceCommands/Show_object/15/zlica.jpg",           null, true),
                                                    new ent::Picture.AnswerPicture(177, @"Resources/Images/VoiceCommands/Show_object/15/mali_zeleni_vrc.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/p_zlicu1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          40,
                                   name:        "Pokaži kuhaču",
                                   description: "U ovom zadatku treba pokazati kuhaču u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(178, @"Resources/Images/VoiceCommands/Show_object/16/duboki2.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(179, @"Resources/Images/VoiceCommands/Show_object/16/tanjur.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(180, @"Resources/Images/VoiceCommands/Show_object/16/slavina.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(181, @"Resources/Images/VoiceCommands/Show_object/16/kuhaca.jpg",  null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_predmet_zvuk/pokazi_kuhacu1.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          10,
                        name:        "Pokaži obojeni predmet",
                        description: "U ovom testu je potrebno kroz niz zadataka pokazati na točno obojan predmet prema glasovnoj uputi.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          41,
                                   name:        "Pokaži crveni tanjur",
                                   description: "U ovom zadatku treba pokazati crveni tanjur u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_colored_object/1/crveni_lonac_picto.png", null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_colored_object/1/crveni_tanjur.jpg",      null, true),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_colored_object/1/crveni_vrc.png",         null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_colored_object/1/salica.jpg",             null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_boja_predmet/p_crveni_tanjur1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          42,
                                   name:        "Pokaži plavi lonac",
                                   description: "U ovom zadatku treba pokazati plavi lonac u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_colored_object/2/ljubicasti_lonac_picto.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_colored_object/2/plavi_lonac.jpeg",           null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_colored_object/2/zeleni_lonac_picto.jpg",     null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_colored_object/2/zuti_lonac_picto.png",       null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_boja_predmet/p_plavi_lonac1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          43,
                                   name:        "Pokaži zelenu vilicu",
                                   description: "U ovom zadatku treba pokazati zelenu vilicu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_colored_object/3/bowl.png",              null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_colored_object/3/red kitchen chair.png", null, false),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_colored_object/3/greenCup.png",          null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_colored_object/3/greenFork.png",         null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_boja_predmet/p_zelenu_vilicu1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          44,
                                   name:        "Pokaži žutu šalicu",
                                   description: "U ovom zadatku treba pokazati žutu šalicu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_colored_object/4/red glass.png",           null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_colored_object/4/red-casserole.png",       null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_colored_object/4/yellowCup.png",           null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_colored_object/4/green kitchen chair.png", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_boja_predmet/p_zutu_salicu1.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          11,
                        name:        "Pokaži predmet određene boje i veličine",
                        description: "U ovom testu je potrebno kroz niz zadataka pokazati na predmet točne boje i veličine prema glasovnoj uputi.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          45,
                                   name:        "Pokaži mali plavi lonac",
                                   description: "U ovom zadatku treba pokazati mali plavi lonac u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_colored_size/1/crveni_lonac.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_colored_size/1/mali_plavi_lonac.png",   null, true),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_colored_size/1/plavi_vrc.jpeg",         null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_colored_size/1/veliki_plavi_lonac.png", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_boja_velicina/p_m_plavi_lonac1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          46,
                                   name:        "Pokaži mali zeleni vrč",
                                   description: "U ovom zadatku treba pokazati mali zeleni vrč u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_colored_size/2/plavi_vrc.jpeg",     null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_colored_size/2/mali_zeleni_vrc.png",null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_colored_size/2/zeleni_vrc.jpg",     null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_colored_size/2/zuti_vrc.jpg",       null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_boja_velicina/p_mali_zeleni_vrc1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          47,
                                   name:        "Pokaži veliku crvenu šalicu",
                                   description: "U ovom zadatku treba pokazati veliku crvenu šalicu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_colored_size/3/roza salica.jpeg", null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_colored_size/3/salica.jpg",       null, true),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_colored_size/3/salica.png",       null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_colored_size/3/zuti_vrc.jpg",     null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_boja_velicina/p_v_crvenu_salicu1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          48,
                                   name:        "Pokaži veliki žuti tanjur",
                                   description: "U ovom zadatku treba pokazati veliki žuti tanjur u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_colored_size/4/zuti_tanjur.png",   null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_colored_size/4/tanjur.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_colored_size/4/zuti_tanjur.jpeg",  null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_colored_size/4/zeleni_tanjur.jpeg",null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_boja_velicina/p_v_zuti_tanjur1.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          12,
                        name:        "Pokaži predmet prema funkciji",
                        description: "U ovom testu je potrebno kroz niz zadataka pokazati na predmet po njegovoj funkciji prema glasovnoj uputi.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          49,
                                   name:        "Cime brišeš?",
                                   description: "U ovom zadatku treba pokazati na predmet s kojim se briše.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_object_purpose/1/casa.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_object_purpose/1/ubrus2.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_object_purpose/1/zlica.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_object_purpose/1/tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_funkcija/cime_brises.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          50,
                                   name:        "Čime jedeš?",
                                   description: "U ovom zadatku treba pokazati na predmet s kojim jede.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_object_purpose/2/casa.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_object_purpose/2/fork.png",   null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_object_purpose/2/slavina.jpg",null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_object_purpose/2/tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_funkcija/cime_jedes.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          51,
                                   name:        "Čime jedeš juhu?",
                                   description: "U ovom zadatku treba pokazati na predmet s kojim jede juhu.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_object_purpose/3/casa.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_object_purpose/3/ubrus2.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_object_purpose/3/zlica.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_object_purpose/3/tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_funkcija/cime_jedes_juhu.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          52,
                                   name:        "Čime režeš?",
                                   description: "U ovom zadatku treba pokazati na predmet s kojim se reže.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_object_purpose/4/casa.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_object_purpose/4/noz.jpg",   null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_object_purpose/4/zlica.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_object_purpose/4/tanjur.jpg",null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_funkcija/cime_rezes.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          53,
                                   name:        "Iz čega piješ?",
                                   description: "U ovom zadatku treba pokazati na predmet iz kojeg se pije.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_object_purpose/5/casa.jpg",   null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_object_purpose/5/noz.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_object_purpose/5/zlica.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_object_purpose/5/tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_funkcija/iz_cega_pijes1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          54,
                                   name:        "U čemu se kuha?",
                                   description: "U ovom zadatku treba pokazati na predmet u kojem se kuha",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_object_purpose/6/kuhaca.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_object_purpose/6/noz.jpg",          null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_object_purpose/6/plavi_lonac.jpeg", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_object_purpose/6/zlica.jpg",        null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_funkcija/u_cemu_se_kuha1.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          13,
                        name:        "Pokaži radnju",
                        description: "U ovom testu je potrebno kroz niz zadataka mora pokazati tko izvodi određenu radnju.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          55,
                                   name:        "Tko briše?",
                                   description: "U ovom zadatku treba pokazati tko od navedenih osoba briše.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_activity/1/brise.jpg",       null, true),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_activity/1/eating-soup.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_activity/1/guli.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_activity/1/kuha.jpg",        null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_radnje/tko_brise1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          56,
                                   name:        "Tko guli?",
                                   description: "U ovom zadatku treba pokazati tko od navedenih osoba guli.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_activity/2/brise.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_activity/2/eating-soup.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_activity/2/guli.jpg",        null, true),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_activity/2/kuha.jpg",        null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_radnje/tko_guli1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          57,
                                   name:        "Tko jede?",
                                   description: "U ovom zadatku treba pokazati tko od navedenih osoba jede.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_activity/3/brise.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_activity/3/eating-soup.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_activity/3/guli.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_activity/3/kuha.jpg",        null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_radnje/tko_jede1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          58,
                                   name:        "Tko kuha?",
                                   description: "U ovom zadatku treba pokazati tko od navedenih osoba kuha.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/4/brise.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/4/eating-soup.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/4/guli.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/4/kuha.jpg",        null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_radnje/tko_kuha1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          59,
                                   name:        "Tko pere?",
                                   description: "U ovom zadatku treba pokazati tko od navedenih osoba pere.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/5/brise.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/5/pere.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/5/guli.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/5/kuha.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_radnje/tko_pere1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          60,
                                   name:        "Tko pije?",
                                   description: "U ovom zadatku treba pokazati tko od navedenih osoba pije.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/6/brise.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/6/pije.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/6/pere.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/6/kuha.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_radnje/tko_pije1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          61,
                                   name:        "Tko reže?",
                                   description: "U ovom zadatku treba pokazati tko od navedenih osoba reže.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/7/reze.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/7/pere.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/7/guli.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/7/kuha.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_radnje/tko_reze1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          62,
                                   name:        "Tko riba?",
                                   description: "U ovom zadatku treba pokazati tko od navedenih osoba riba.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/8/reze.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/8/pere.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/8/ribanje.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/8/kuha.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_radnje/tko_riba1.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          14,
                        name:        "Pokaži predmet određene veličine",
                        description: "U ovom testu je potrebno kroz niz zadataka pokazati na predmet određene veličine.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          63,
                                   name:        "Pokaži duboki tanjur!",
                                   description: "U ovom zadatku treba pokazati duboki tanjur u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_size/1/tanjur.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_size/1/crveni_tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_size/1/zuti_tanjur.jpeg",  null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_size/1/duboki_tanjur.jpg", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_duboki_tanjur1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          64,
                                   name:        "Pokaži mali nož!",
                                   description: "U ovom zadatku dijete pokazati mali nož u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_size/2/tava.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_size/2/noz.png",        null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_size/2/veliki_noz.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_size/2/zlica.jpg",      null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_mali_noz1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          65,
                                   name:        "Pokaži mali vrč!",
                                   description: "U ovom zadatku treba pokazati mali vrč u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_size/3/zuti_vrc.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_size/3/zeleni_vrc.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_size/3/plavi_vrc.jpeg",  null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_size/3/crveni_vrc.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_mali_vrc.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          66,
                                   name:        "Pokaži malu kuhaču!",
                                   description: "U ovom zadatku treba pokazati malu kuhaču u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/4/bat.jpg",         null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/4/kuhaca.jpg",      null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/4/mala_kuhaca.png", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/4/zlica.jpg",       null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_malu_kuhacu1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          67,
                                   name:        "Pokaži malu žlicu!",
                                   description: "U ovom zadatku treba pokazati malu žlicu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/5/bat.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/5/kuhaca.jpg",     null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/5/mala_zlica.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/5/zlica.png",      null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_malu_zlicu1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          68,
                                   name:        "Pokaži najmanju dasku!",
                                   description: "U ovom zadatku treba pokazati najmanju dasku u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/6/m_daska.png", null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/6/kuhaca.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/6/daska.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/6/v_daska.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_najmanju_dasku1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          69,
                                   name:        "Pokaži največu tavu!",
                                   description: "U ovom zadatku treba pokazati najveću tavu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/7/pan.jpg",    null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/7/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/7/v_tava.png", null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/7/tava.png",   null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_najvecu_tavu1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          70,
                                   name:        "Pokaži plitki tanjur!",
                                   description: "U ovom zadatku treba pokazati plitki tanjur u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/8/tanjur.jpg",        null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/8/d_plate.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/8/d_plate2.jpg",      null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/8/duboki_tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_plitki_tanjur1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          71,
                                   name:        "Pokaži veliku kuhaču!",
                                   description: "U ovom zadatku treba pokazati veliku kuhaču u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/9/bat.jpg",         null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/9/kuhaca.jpg",      null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/9/mala_kuhaca.png", null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/9/zlica.jpg",       null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_veliku_kuhacu1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          72,
                                   name:        "Pokaži veliki lonac!",
                                   description: "U ovom zadatku treba pokazati veliki lonac u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/10/crveni_lonac.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/10/mali_plavi_lonac.png",   null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/10/pan.jpg",                null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/10/veliki_plavi_lonac.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_veliki_lonac1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          73,
                                   name:        "Pokaži veliki tanjur!",
                                   description: "U ovom zadatku treba pokazati veliki tanjur u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/11/tanjur.png",   null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/11/m_tanjur.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/11/pan.jpg",      null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/11/daska.jpg",    null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_veliki_tanjur1.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          74,
                                   name:        "Pokaži veliku čašu!",
                                   description: "U ovom zadatku treba pokazati veliku čašu u nizu od 4 predmeta.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/12/vrč.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/12/casa.png",       null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/12/v_casa.jpg",     null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/12/zuta_salica.png",null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Zadaci_zvuk/pokazi_velicina/p_veliku_casu1.mp3"), "title")
                                   ),
                               }),
                    }
                    .ToList();
        }
        private static IEnumerable<ent::Test> PrivateDataModel_En()
        {
            return
                new[]
                    {
                        new ent::Test
                        (
                        id:          2,
                        name:        "Continue sequence",
                        description: "The objective of this test is to recognize through three tasks which items continue a given sequence of items.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          4,
                                   name:        "Continue sequence, Difficulty 1",
                                   description: "In this task the objective is to recognize which item continues the sequence of two items. The task can be solved by clicking on the correct item in the vertical list.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-continue-sequence-256x256.png"),
                                   type:        "#004",
                                   difficulty:   1,
                                          
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                     new ent::Picture.AnswerPicture(21, @"Resources/Images/ContinueSequence/1/bowl.png",     null, false ),
                                                     new ent::Picture.AnswerPicture(22, @"Resources/Images/ContinueSequence/1/casserole.png",null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/continue_sequence.mp3"), "title")
                                  ),
                                  new ent::Task
                                   (
                                   id:          5,
                                   name:        "Continue sequence, Difficulty 2",
                                   description: "In this task the objective is to recognize which item continues the sequence of three items. The task can be solved by clicking on the correct items in the vertical list.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-continue-sequence-256x256.png"),
                                   type:        "#004",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                     new ent::Picture.AnswerPicture(23, @"Resources/Images/ContinueSequence/2/coffee cup.png", null, false ),
                                                     new ent::Picture.AnswerPicture(24, @"Resources/Images/ContinueSequence/2/cup.png",        null, false),
                                                     new ent::Picture.AnswerPicture(25, @"Resources/Images/ContinueSequence/2/frying pan.png", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/continue_sequence.mp3"), "title")
                                  ),
                                  new ent::Task
                                   (
                                   id:          6,
                                   name:        "Continue sequence, Difficulty 3",
                                   description: "In this task the objective is to recognize which item continues the sequence of four items. The task can be solved by clicking on the correct items in the vertical list.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-continue-sequence-256x256.png"),
                                   type:        "#004",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                     new ent::Picture.AnswerPicture(25, @"Resources/Images/ContinueSequence/3/full.png",          null, false ),
                                                     new ent::Picture.AnswerPicture(26, @"Resources/Images/ContinueSequence/3/jug.png",           null, false),
                                                     new ent::Picture.AnswerPicture(22, @"Resources/Images/ContinueSequence/3/kitchen chair.png", null, false),
                                                     new ent::Picture.AnswerPicture(27, @"Resources/Images/ContinueSequence/3/glass.png",         null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/continue_sequence.mp3"), "title")
                                  ),
                               }),
                        new ent::Test
                        (
                        id:          3,
                        name:        "Detect colors",
                        description: "The objective of this test is to recognize through three tasks the colors of given items.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          7,
                                   name:        "Detect colors, Difficulty 1",
                                   description: "In this task the objective is to recognize the color of each of the six given items. The choice is between two given colors.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-colors-256x256.png"),
                                   type:        "#003",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.ColorPicture>
                                                {
                                                    new ent::Picture.ColorPicture(30, @"Resources/Images/DetectColors/1/bowl.png",                null, new List<ent::Color>{new ent::Color(1, "#0000FF", true, 28),new ent::Color(1, "#FF0000", false, 28)}),
                                                    new ent::Picture.ColorPicture(31, @"Resources/Images/DetectColors/1/red-casserole.png",      null, new List<ent::Color>{new ent::Color(1, "#FF0000", true, 28),new ent::Color(1, "#A52A2A", false, 29)}),
                                                    new ent::Picture.ColorPicture(32, @"Resources/Images/DetectColors/1/blue coffee cup.png",    null, new List<ent::Color>{new ent::Color(1, "#0000FF", true, 28),new ent::Color(1, "#800080", false, 30)}),
                                                    new ent::Picture.ColorPicture(33, @"Resources/Images/DetectColors/1/greenCup.png",           null, new List<ent::Color>{new ent::Color(1, "#008000", true, 28),new ent::Color(1, "#FFA500", false, 31)}),
                                                    new ent::Picture.ColorPicture(34, @"Resources/Images/DetectColors/1/red glass.png",          null, new List<ent::Color>{new ent::Color(1, "#FF0000", true, 28),new ent::Color(1, "#008000", false, 32)}),
                                                    new ent::Picture.ColorPicture(35, @"Resources/Images/DetectColors/1/green kitchen chair.png",null, new List<ent::Color>{new ent::Color(1, "#008000", true, 28),new ent::Color(1, "#0000FF", false, 33)})
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/detect_colors.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          8,
                                   name:        "Detect colors, Difficulty 2",
                                   description: "In this task the objective is to recognize the color of each of the four given items. The choice is between four given colors.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-colors-256x256.png"),
                                   type:        "#003",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.ColorPicture>
                                                {
                                                    new ent::Picture.ColorPicture(36, @"Resources/Images/DetectColors/2/bowl.png",                 null, new List<ent::Color>{new ent::Color(1, "#0000FF", true, 28),new ent::Color(1, "#008000", false, 34),new ent::Color(1, "#A52A2A", false, 28),new ent::Color(1, "#FFA500", false, 34)}),
                                                    new ent::Picture.ColorPicture(37, @"Resources/Images/DetectColors/2/greenCup.png",             null, new List<ent::Color>{new ent::Color(1, "#008000", true, 28),new ent::Color(1, "#FFA500", false, 35),new ent::Color(1, "#0000FF", false, 28),new ent::Color(1, "#A52A2A", false, 35)}),
                                                    new ent::Picture.ColorPicture(38, @"Resources/Images/DetectColors/2/red kitchen chair.png",    null, new List<ent::Color>{new ent::Color(1, "#FF0000", true, 28),new ent::Color(1, "#008000", false, 36),new ent::Color(1, "#FFA500", false, 28),new ent::Color(1, "#0000FF", false, 36)}),
                                                    new ent::Picture.ColorPicture(39, @"Resources/Images/DetectColors/2/yellow kitchen tool_3.png",null, new List<ent::Color>{new ent::Color(1, "#FFFF00", true, 28),new ent::Color(1, "#0000FF", false, 37),new ent::Color(1, "#FFA500", false, 28),new ent::Color(1, "#008000", false, 37)})
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/detect_colors.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          9,
                                   name:        "Detect colors, Difficulty 3",
                                   description: "In this task the objective is to recognize the color of two given items. The choice is between six given colors.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-colors-256x256.png"),
                                   type:        "#003",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.ColorPicture>
                                                {
                                                    new ent::Picture.ColorPicture(40, @"Resources/Images/DetectColors/3/red kitchen chair.png",null, new List<ent::Color>{new ent::Color(1, "#FF0000", true, 28),new ent::Color(1, "#008000", false, 34),new ent::Color(1, "#FFA500", false, 28),new ent::Color(1, "#0000FF", false, 34),new ent::Color(1, "#A52A2A", false, 34),new ent::Color(1, "#FFFF00", false, 34)}),
                                                    new ent::Picture.ColorPicture(41, @"Resources/Images/DetectColors/3/greenCup.png",         null, new List<ent::Color>{new ent::Color(1, "#008000", true, 28),new ent::Color(1, "#FF0000", false, 35),new ent::Color(1, "#0000FF", false, 28),new ent::Color(1, "#FFA500", false, 35),new ent::Color(1, "#FFFF00", false, 35),new ent::Color(1, "#A52A2A", false, 35)})
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/detect_colors.mp3"), "title")
                                   )}),
                        new ent::Test
                        (
                        id:          4,
                        name:        "Detect different items",
                        description: "The objective of this test is to recognize through three tasks which items do not belong in a sequence of same items.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          10,
                                   name:        "Detect different item, Difficulty 1",
                                   description: "In this task the objective is to recognize an item that is different from others in a list of same items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-different-items-256x256.png"),
                                   type:        "#002",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(28, @"Resources/Images/DetectDifferentItems/1/bowl.png",           null, true ),
                                                    new ent::Picture.AnswerPicture(29, @"Resources/Images/DetectDifferentItems/1/casserole.png",      null, false),
                                                    new ent::Picture.AnswerPicture(30, @"Resources/Images/DetectDifferentItems/1/frying pan.png",     null, false),
                                                    new ent::Picture.AnswerPicture(31, @"Resources/Images/DetectDifferentItems/1/glass.png",          null, false),
                                                    new ent::Picture.AnswerPicture(32, @"Resources/Images/DetectDifferentItems/1/kitchen tool_2.png", null, false),
                                                    new ent::Picture.AnswerPicture(33, @"Resources/Images/DetectDifferentItems/1/plate_1.png",        null, false)
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/detecet_different.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          11,
                                   name:        "Detect different item, Difficulty  2",
                                   description: "In this task the objective is to recognize an item that is different in a set of scattered items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-different-items-256x256.png"),
                                   type:        "#002",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(34, @"Resources/Images/DetectDifferentItems/2/lonac.png",             null, true ),
                                                    new ent::Picture.AnswerPicture(35, @"Resources/Images/DetectDifferentItems/2/Red_cambridge_mug.png", null, false),
                                                    
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/detecet_different.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          12,
                                   name:        "Detect different item, Difficulty  3",
                                   description: "In this task the objective is to recognize an item that is different, but similar to items in a set of scattered items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-detect-different-items-256x256.png"),
                                   type:        "#002",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(36, @"Resources/Images/DetectDifferentItems/3/individual-red-mug.png", null, true ),
                                                    new ent::Picture.AnswerPicture(37, @"Resources/Images/DetectDifferentItems/3/Red_cambridge_mug.png",  null, false),  
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/detecet_different.mp3"), "title")
                                   )}),

                        new ent::Test
                        (
                        id:          6,
                        name:        "Pair halves",
                        description: "The objective of this test is to recognize and pair the halves of each given item through three tasks.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          16,
                                   name:        "Pair halves, Difficulty 1",
                                   description: "In this task the objective is to pair halves of two items by dragging from the bottom list of halves next to the correct half.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-halves-256x256.png"),
                                   type:        "#005",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.BasicDetails>
                                                {
                                                   new ent::Picture.BasicDetails(67, @"Resources/Images/PairHalfs/1/bowl.png"),
                                                   new ent::Picture.BasicDetails(68, @"Resources/Images/PairHalfs/1/casserole.png"),
                                                   new ent::Picture.BasicDetails(69, @"Resources/Images/PairHalfs/1/plate_1.png"),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/pair_halves.mp3"), "title")                                                                                                  
                                   ),
                                   new ent::Task
                                   (
                                   id:          17,
                                   name:        "Pair halves, Difficulty 2",
                                   description: "In this task the objective is to pair halves of five items by dragging from the bottom list of halves next to the correct half.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-halves-256x256.png"),
                                   type:        "#005",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.BasicDetails>
                                                {
                                                   new ent::Picture.BasicDetails(67, @"Resources/Images/PairHalfs/2/bowl.png"),
                                                   new ent::Picture.BasicDetails(68, @"Resources/Images/PairHalfs/2/casserole.png"),
                                                   new ent::Picture.BasicDetails(69, @"Resources/Images/PairHalfs/2/coffee cup.png"),
                                                   new ent::Picture.BasicDetails(70, @"Resources/Images/PairHalfs/2/full.png"),
                                                   new ent::Picture.BasicDetails(71, @"Resources/Images/PairHalfs/2/jug.png"),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/pair_halves.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          18,
                                   name:        "Pair halves, Difficulty 3",
                                   description: "In this task the objective is to pair halves of seven items by dragging from the bottom list of halves next to the correct half.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-halves-256x256.png"),
                                   type:        "#005",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.BasicDetails>
                                                {
                                                   new ent::Picture.BasicDetails(67, @"Resources/Images/PairHalfs/3/bowl.png"),
                                                   new ent::Picture.BasicDetails(68, @"Resources/Images/PairHalfs/3/casserole.png"),
                                                   new ent::Picture.BasicDetails(69, @"Resources/Images/PairHalfs/3/coffee cup.png"),
                                                   new ent::Picture.BasicDetails(70, @"Resources/Images/PairHalfs/3/full.png"),
                                                   new ent::Picture.BasicDetails(71, @"Resources/Images/PairHalfs/3/jug.png"),
                                                   new ent::Picture.BasicDetails(72, @"Resources/Images/PairHalfs/3/kitchen tool_2.png"),
                                                   new ent::Picture.BasicDetails(73, @"Resources/Images/PairHalfs/3/plate_1.png"),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/pair_halves.mp3"), "title")                                                                                                   
                                   )}),
                        new ent::Test
                        (
                        id:          7,
                        name:        "Pair items",
                        description: "In this test, through three tasks, the objective is to recognize and pair given items.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          19,
                                   name:        "Pair items, Difficulty 1",
                                   description: "In this task the objective is to pair three items by dragging them from the bottom list next to the correct item.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-same-items-256x256.png"),
                                   type:        "#001",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(75, @"Resources/Images/PairSameItems/1/kitchen tool_2.png", null, true),
                                                    new ent::Picture.AnswerPicture(76, @"Resources/Images/PairSameItems/1/kitchen tool_3.png", null, true),
                                                    new ent::Picture.AnswerPicture(77, @"Resources/Images/PairSameItems/1/kitchen tool_6.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/pair_items.mp3"), "title")
                                   ),
                                    new ent::Task
                                   (
                                   id:          20,
                                   name:        "Pair items, Difficulty 2",
                                   description: "In this task the objective is to pair five items by dragging them from the bottom list next to the correct item.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-same-items-256x256.png"),
                                   type:        "#001",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(78, @"Resources/Images/PairSameItems/2/bowl.png",          null, true),
                                                    new ent::Picture.AnswerPicture(79, @"Resources/Images/PairSameItems/2/casserole.png",     null, true),
                                                    new ent::Picture.AnswerPicture(80, @"Resources/Images/PairSameItems/2/cup.png",           null, true),
                                                    new ent::Picture.AnswerPicture(81, @"Resources/Images/PairSameItems/2/kitchen chair.png", null, true),
                                                    new ent::Picture.AnswerPicture(101, @"Resources/Images/PairSameItems/2/frying pan.png",   null, true)
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/pair_items.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          21,
                                   name:        "Pair items, Difficulty 3",
                                   description: "In this task the objective is to pair seven items by dragging them from the bottom list next to the correct item.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-pair-same-items-256x256.png"),
                                   type:        "#001",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(81, @"Resources/Images/PairSameItems/3/17622157-orange-juice-in-a-jug.png", null, true),
                                                    new ent::Picture.AnswerPicture(82, @"Resources/Images/PairSameItems/3/693024_1.png",                       null, true),
                                                    new ent::Picture.AnswerPicture(83, @"Resources/Images/PairSameItems/3/9620-08240.png",                     null, true),
                                                    new ent::Picture.AnswerPicture(84, @"Resources/Images/PairSameItems/3/casa1.png",                          null, true),
                                                    new ent::Picture.AnswerPicture(85, @"Resources/Images/PairSameItems/3/kitchen-tool_2.png",                 null, true),
                                                    new ent::Picture.AnswerPicture(86, @"Resources/Images/PairSameItems/3/plate_1.png",                        null, true)
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/pair_items.mp3"), "title")
                                   )
                               }),
                        new ent::Test
                        (
                        id:          8,
                        name:        "Sort items by size",
                        description: "In this test, through three tasks, the objective is to sort items by their size.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          22,
                                   name:        "Sort items by size, Difficulty 1",
                                   description: "In this task the objective is to sort the given three items by their size. Clicking on a correct item puts it on the sorted list.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-order-by-size-256x256.png"),
                                   type:        "#008",
                                   difficulty:   3,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(87, @"Resources/Images/SortBySize/1/jug-1.png", null, true),
                                                    new ent::Picture.AnswerPicture(88, @"Resources/Images/SortBySize/1/jug-2.png", null, true),
                                                    new ent::Picture.AnswerPicture(89, @"Resources/Images/SortBySize/1/jug-3.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/sort_size.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          23,
                                   name:        "Sort items by size, Difficulty 2",
                                   description: "In this task the objective is to sort the given four items by their size. Clicking on a correct item puts it on the sorted list.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-order-by-size-256x256.png"),
                                   type:        "#008",
                                   difficulty:   4,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(90, @"Resources/Images/SortBySize/2/kitchen-tool_2-1.png", null, true),
                                                    new ent::Picture.AnswerPicture(91, @"Resources/Images/SortBySize/2/kitchen-tool_2-2.png", null, true),
                                                    new ent::Picture.AnswerPicture(92, @"Resources/Images/SortBySize/2/kitchen-tool_2-3.png", null, true),
                                                    new ent::Picture.AnswerPicture(93, @"Resources/Images/SortBySize/2/kitchen-tool_2-4.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/sort_size.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          24,
                                   name:        "Sort items by size, Difficulty 3",
                                   description: "In this task the objective is to sort the given five items by their size. Clicking on a correct item puts it on the sorted list.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-order-by-size-256x256.png"),
                                   type:        "#008",
                                   difficulty:   5,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(93, @"Resources/Images/SortBySize/3/cup-1.png", null, true),
                                                    new ent::Picture.AnswerPicture(94, @"Resources/Images/SortBySize/3/cup-2.png", null, true),
                                                    new ent::Picture.AnswerPicture(95, @"Resources/Images/SortBySize/3/cup-3.png", null, true),
                                                    new ent::Picture.AnswerPicture(96, @"Resources/Images/SortBySize/3/cup-4.png", null, true),
                                                    new ent::Picture.AnswerPicture(97, @"Resources/Images/SortBySize/3/cup-5.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/sort_size.mp3"), "title")
                                   )
                               }),
                        new ent::Test
                        (
                        id:          9,
                        name:        "Show an item",
                        description: "In this test, the objective is to show a correct item from a set of items, given by a voice command.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          25,
                                   name:        "Show a drinking glass",
                                   description: "In this task the objective is to point to a drinking glass from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_object/1/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_object/1/casa.jpg",   null, true),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_object/1/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_object/1/ubrus.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_drinking_glass.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          26,
                                   name:        "Show a meat hammer",
                                   description: "In this task the objective is to point to a meat hammer from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_object/2/casa.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_object/2/bat.jpg",   null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_object/2/tava.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_object/2/ubrus.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_meat_hamm.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          27,
                                   name:        "Show a kitchen board",
                                   description: "In this task the objective is to point to a kitchen board from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_object/3/bat.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_object/3/casa.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_object/3/tava.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_object/3/daska.jpg", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_kitchen_b.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          28,
                                   name:        "Show a kitchen",
                                   description: "In this task the objective is to point to a kitchen from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_object/4/bat.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_object/4/casa.jpg",      null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_object/4/kitchen41.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_object/4/daska.jpg",     null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_kitchen.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          29,
                                   name:        "Show a casserole",
                                   description: "In this task the objective is to point to a casserole from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(134, @"Resources/Images/VoiceCommands/Show_object/5/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(135, @"Resources/Images/VoiceCommands/Show_object/5/lonac.png",  null, true),
                                                    new ent::Picture.AnswerPicture(136, @"Resources/Images/VoiceCommands/Show_object/5/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(137, @"Resources/Images/VoiceCommands/Show_object/5/ubrus.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_casserole.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          30,
                                   name:        "Show a knife",
                                   description: "In this task the objective is to point to a knife from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(138, @"Resources/Images/VoiceCommands/Show_object/6/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(139, @"Resources/Images/VoiceCommands/Show_object/6/noz.jpg",    null, true),
                                                    new ent::Picture.AnswerPicture(140, @"Resources/Images/VoiceCommands/Show_object/6/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(141, @"Resources/Images/VoiceCommands/Show_object/6/ubrus.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_knife.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          31,
                                   name:        "Show a cup",
                                   description: "In this task the objective is to point to a cup from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(142, @"Resources/Images/VoiceCommands/Show_object/7/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(143, @"Resources/Images/VoiceCommands/Show_object/7/salica.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(144, @"Resources/Images/VoiceCommands/Show_object/7/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(145, @"Resources/Images/VoiceCommands/Show_object/7/ubrus.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_cup.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          32,
                                   name:        "Show a faucet",
                                   description: "In this task the objective is to point to a faucet from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(146, @"Resources/Images/VoiceCommands/Show_object/8/tanjur.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(147, @"Resources/Images/VoiceCommands/Show_object/8/slavina.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(148, @"Resources/Images/VoiceCommands/Show_object/8/casa.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(149, @"Resources/Images/VoiceCommands/Show_object/8/daska.jpg",   null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_faucet.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          33,
                                   name:        "Show a sink",
                                   description: "In this task the objective is to point to a sink from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(150, @"Resources/Images/VoiceCommands/Show_object/9/tanjur.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(151, @"Resources/Images/VoiceCommands/Show_object/9/sudoper.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(152, @"Resources/Images/VoiceCommands/Show_object/9/casa.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(153, @"Resources/Images/VoiceCommands/Show_object/9/daska.jpg",   null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_sink.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          34,
                                   name:        "Show a plate",
                                   description: "In this task the objective is to point to a plate from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(154, @"Resources/Images/VoiceCommands/Show_object/10/slavina.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(155, @"Resources/Images/VoiceCommands/Show_object/10/tanjur.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(156, @"Resources/Images/VoiceCommands/Show_object/10/casa.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(157, @"Resources/Images/VoiceCommands/Show_object/10/daska.jpg",   null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_plate.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          35,
                                   name:        "Show a pan",
                                   description: "In this task the objective is to point to a pan from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(158, @"Resources/Images/VoiceCommands/Show_object/11/bat.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(159, @"Resources/Images/VoiceCommands/Show_object/11/tava.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(160, @"Resources/Images/VoiceCommands/Show_object/11/casa.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(161, @"Resources/Images/VoiceCommands/Show_object/11/ubrus.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_pan.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          36,
                                   name:        "Show a napkin",
                                   description: "In this task the objective is to point to a napkin from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(162, @"Resources/Images/VoiceCommands/Show_object/12/tava.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(163, @"Resources/Images/VoiceCommands/Show_object/12/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(164, @"Resources/Images/VoiceCommands/Show_object/12/casa.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(165, @"Resources/Images/VoiceCommands/Show_object/12/ubrus.jpg",  null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_napkin.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          37,
                                   name:        "Show a fork",
                                   description: "In this task the objective is to point to a fork from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(166, @"Resources/Images/VoiceCommands/Show_object/13/tanjur.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(167, @"Resources/Images/VoiceCommands/Show_object/13/zuti_tanjur.jpeg", null, false),
                                                    new ent::Picture.AnswerPicture(168, @"Resources/Images/VoiceCommands/Show_object/13/ubrus2.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(169, @"Resources/Images/VoiceCommands/Show_object/13/fork.png",         null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_fork.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          38,
                                   name:        "Show a jug",
                                   description: "In this task the objective is to point to a jug from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(170, @"Resources/Images/VoiceCommands/Show_object/14/noz.jpg",           null, false),
                                                    new ent::Picture.AnswerPicture(171, @"Resources/Images/VoiceCommands/Show_object/14/duboki_tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(172, @"Resources/Images/VoiceCommands/Show_object/14/vrč.jpg",           null, true),
                                                    new ent::Picture.AnswerPicture(173, @"Resources/Images/VoiceCommands/Show_object/14/zlica.jpg",         null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_jug.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          39,
                                   name:        "Show a spoon",
                                   description: "In this task the objective is to point to a spoon from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(174, @"Resources/Images/VoiceCommands/Show_object/15/slavina.jpg",         null, false),
                                                    new ent::Picture.AnswerPicture(175, @"Resources/Images/VoiceCommands/Show_object/15/tanjur.jpg",          null, false),
                                                    new ent::Picture.AnswerPicture(176, @"Resources/Images/VoiceCommands/Show_object/15/zlica.jpg",           null, true),
                                                    new ent::Picture.AnswerPicture(177, @"Resources/Images/VoiceCommands/Show_object/15/mali_zeleni_vrc.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_spoon.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          40,
                                   name:        "Show a cooking spoon",
                                   description: "In this task the objective is to point to a cooking spoon from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(178, @"Resources/Images/VoiceCommands/Show_object/16/duboki2.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(179, @"Resources/Images/VoiceCommands/Show_object/16/tanjur.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(180, @"Resources/Images/VoiceCommands/Show_object/16/slavina.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(181, @"Resources/Images/VoiceCommands/Show_object/16/kuhaca.jpg",  null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_item/s_cooking_spoon.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          10,
                        name:        "Show an item with correct color",
                        description: "In this test, the objective is to show a correct item by color, given by a voice command.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          41,
                                   name:        "Show a red plate",
                                   description: "In this task the objective is to point to a red plate from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_colored_object/1/crveni_lonac_picto.png", null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_colored_object/1/crveni_tanjur.jpg",      null, true),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_colored_object/1/crveni_vrc.png",         null, false),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_colored_object/1/salica.jpg",             null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_color/s_red_plate.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          42,
                                   name:        "Show a blue casserole",
                                   description: "In this task the objective is to point to a blue casserole from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_colored_object/2/ljubicasti_lonac_picto.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_colored_object/2/plavi_lonac.jpeg",           null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_colored_object/2/zeleni_lonac_picto.jpg",     null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_colored_object/2/zuti_lonac_picto.png",       null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_color/s_blue_cass.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          43,
                                   name:        "Show a green fork",
                                   description: "In this task the objective is to point to a green fork from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_colored_object/3/bowl.png",              null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_colored_object/3/red kitchen chair.png", null, false),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_colored_object/3/greenCup.png",          null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_colored_object/3/greenFork.png",         null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_color/s_green_fork.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          44,
                                   name:        "Show a yellow spoon",
                                   description: "In this task the objective is to point to a yellow spoon from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_colored_object/4/red glass.png",           null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_colored_object/4/red-casserole.png",       null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_colored_object/4/yellowspoon.png",         null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_colored_object/4/green kitchen chair.png", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_color/s_yellow_spoon.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          11,
                        name:        "Show an item with correct color and size",
                        description: "In this test, the objective is to show a correct item by color and size from a set of items given by a voice command.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          45,
                                   name:        "Show a small blue casserole",
                                   description: "In this task the objective is to point to a small blue casserole from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_colored_size/1/crveni_lonac.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_colored_size/1/mali_plavi_lonac.png",   null, true),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_colored_size/1/plavi_vrc.jpeg",         null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_colored_size/1/veliki_plavi_lonac.png", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_color_size/s_small_b_cass.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          46,
                                   name:        "Show a small green jug",
                                   description: "In this task the objective is to point to a small green jug from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_colored_size/2/plavi_vrc.jpeg",     null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_colored_size/2/mali_zeleni_vrc.png",null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_colored_size/2/zeleni_vrc.jpg",     null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_colored_size/2/zuti_vrc.jpg",       null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_color_size/s_small_green_jug.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          47,
                                   name:        "Show a big red cup",
                                   description: "In this task the objective is to point to a big red cup from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_colored_size/3/roza salica.jpeg", null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_colored_size/3/salica.jpg",       null, true),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_colored_size/3/salica.png",       null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_colored_size/3/zuti_vrc.jpg",     null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_color_size/s_big_red_cup.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          48,
                                   name:        "Show a big yellow plate",
                                   description: "In this task the objective is to point to a big yellow plate from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_colored_size/4/zuti_tanjur.png",   null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_colored_size/4/tanjur.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_colored_size/4/zuti_tanjur.jpeg",  null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_colored_size/4/zeleni_tanjur.jpeg",null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_color_size/s_big_yellow_plate.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          12,
                        name:        "Show an item by its purpose",
                        description: "In this test, the objective is to show a correct item by its purpose from a set of items, by a given voice command.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          49,
                                   name:        "With what do you wipe?",
                                   description: "In this task the objective is to point to an item which is used for wiping.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_object_purpose/1/casa.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_object_purpose/1/ubrus2.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_object_purpose/1/zlica.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_object_purpose/1/tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Item_by_purpose/w_wipe.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          50,
                                   name:        "With what do you eat?",
                                   description: "In this task the objective is to point to an item which is used for eating.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_object_purpose/2/casa.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_object_purpose/2/fork.png",   null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_object_purpose/2/slavina.jpg",null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_object_purpose/2/tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Item_by_purpose/w_eat.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          51,
                                   name:        "With what do you eat soup?",
                                   description: "In this task the objective is to point to an item which is used for eating soup.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_object_purpose/3/casa.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_object_purpose/3/ubrus2.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_object_purpose/3/zlica.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_object_purpose/3/tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Item_by_purpose/w_eat_soup.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          52,
                                   name:        "With what do you cut?",
                                   description: "In this task the objective is to point to an item which is used for cutting.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_object_purpose/4/casa.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_object_purpose/4/noz.jpg",   null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_object_purpose/4/zlica.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_object_purpose/4/tanjur.jpg",null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Item_by_purpose/w_cut.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          53,
                                   name:        "With what do you drink?",
                                   description: "In this task the objective is to point to an item which is used for drinking.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_object_purpose/5/casa.jpg",   null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_object_purpose/5/noz.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_object_purpose/5/zlica.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_object_purpose/5/tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Item_by_purpose/w_drink.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          54,
                                   name:        "With what can you cook?",
                                   description: "In this task the objective is to point to an item which is used for cooking.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_object_purpose/6/kuhaca.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_object_purpose/6/noz.jpg",          null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_object_purpose/6/plavi_lonac.jpeg", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_object_purpose/6/zlica.jpg",        null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Item_by_purpose/w_cook.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          13,
                        name:        "Show who is doing an activity",
                        description: "In this test, the objective is to show a correct activity from a set of activities, given by a voice command.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          55,
                                   name:        "Who is wiping?",
                                   description: "In this task the objective is to point to a person who is wiping.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_activity/1/brise.jpg",       null, true),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_activity/1/eating-soup.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_activity/1/guli.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_activity/1/kuha.jpg",        null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_activity/w_wiping.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          56,
                                   name:        "Who is peeling?",
                                   description: "In this task the objective is to point to a person who is peeling.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_activity/2/brise.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_activity/2/eating-soup.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_activity/2/guli.jpg",        null, true),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_activity/2/kuha.jpg",        null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_activity/w_peeling.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          57,
                                   name:        "Who is eating?",
                                   description: "In this task the objective is to point to a person who is eating.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_activity/3/brise.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_activity/3/eating-soup.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_activity/3/guli.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_activity/3/kuha.jpg",        null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_activity/w_eating.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          58,
                                   name:        "Who is cooking?",
                                   description: "In this task the objective is to point to a person who is cooking.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/4/brise.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/4/eating-soup.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/4/guli.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/4/kuha.jpg",        null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_activity/w_cooking.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          59,
                                   name:        "Who is washing?",
                                   description: "In this task the objective is to point to a person who is washing.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/5/brise.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/5/pere.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/5/guli.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/5/kuha.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_activity/w_washing.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          60,
                                   name:        "Who is drinking?",
                                   description: "In this task the objective is to point to a person who is drinking.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/6/brise.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/6/pije.jpg",  null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/6/pere.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/6/kuha.jpg",  null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_activity/w_drinking.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          61,
                                   name:        "Who is cutting?",
                                   description: "In this task the objective is to point to a person who is cutting.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/7/reze.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/7/pere.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/7/guli.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/7/kuha.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_activity/w_cutting.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          62,
                                   name:        "Who is scrubbing?",
                                   description: "In this task the objective is to point to a person who is scrubbing.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_activity/8/reze.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_activity/8/pere.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_activity/8/ribanje.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_activity/8/kuha.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_activity/w_scrubbing.mp3"), "title")
                                   ),
                               }),
                        new ent::Test
                        (
                        id:          14,
                        name:        "Show an item by its size",
                        description: "In this test, the objective is to show a correct item by its size, given by a voice command.",
                        tasks: new List<ent::Task>
                               {
                                   new ent::Task
                                   (
                                   id:          63,
                                   name:        "Show a deep plate!",
                                   description: "In this task the objective is to point to a deep plate from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(119, @"Resources/Images/VoiceCommands/Show_size/1/tanjur.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(120, @"Resources/Images/VoiceCommands/Show_size/1/crveni_tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(121, @"Resources/Images/VoiceCommands/Show_size/1/zuti_tanjur.jpeg",  null, false),
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_size/1/duboki_tanjur.jpg", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_deep_plate.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          64,
                                   name:        "Show a small knife!",
                                   description: "In this task the objective is to point to a small knife from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(122, @"Resources/Images/VoiceCommands/Show_size/2/tava.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(123, @"Resources/Images/VoiceCommands/Show_size/2/noz.png",        null, true),
                                                    new ent::Picture.AnswerPicture(124, @"Resources/Images/VoiceCommands/Show_size/2/veliki_noz.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(125, @"Resources/Images/VoiceCommands/Show_size/2/zlica.jpg",      null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_small_knife.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          65,
                                   name:        "Show a small jug!",
                                   description: "In this task the objective is to point to a small jug from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(126, @"Resources/Images/VoiceCommands/Show_size/3/zuti_vrc.jpg",    null, false),
                                                    new ent::Picture.AnswerPicture(127, @"Resources/Images/VoiceCommands/Show_size/3/zeleni_vrc.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(128, @"Resources/Images/VoiceCommands/Show_size/3/plavi_vrc.jpeg",  null, false),
                                                    new ent::Picture.AnswerPicture(129, @"Resources/Images/VoiceCommands/Show_size/3/crveni_vrc.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_small_jug.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          66,
                                   name:        "Show a small cooking spoon!",
                                   description: "In this task the objective is to point to a small cooking spoon from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/4/bat.jpg",         null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/4/kuhaca.jpg",      null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/4/mala_kuhaca.png", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/4/zlica.jpg",       null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_small_c_spoon.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          67,
                                   name:        "Show a small spoon!",
                                   description: "In this task the objective is to point to a small spoon from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/5/bat.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/5/kuhaca.jpg",     null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/5/mala_zlica.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/5/zlica.png",      null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_small_spoon.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          68,
                                   name:        "Show the smallest kitchen board!",
                                   description: "In this task the objective is to point to the smallest kitchen board from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/6/m_daska.png", null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/6/kuhaca.jpg",  null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/6/daska.jpg",   null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/6/v_daska.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_smallest_kb.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          69,
                                   name:        "Show the biggest pan!",
                                   description: "In this task the objective is to point to the biggest pan from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/7/pan.jpg",    null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/7/tanjur.jpg", null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/7/v_tava.png", null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/7/tava.png",   null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_biggest_pan.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          70,
                                   name:        "Show a shallow plate!",
                                   description: "In this task the objective is to point to a shallow plate from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/8/tanjur.jpg",        null, true),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/8/d_plate.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/8/d_plate2.jpg",      null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/8/duboki_tanjur.jpg", null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_shallow_plate.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          71,
                                   name:        "Show a big cooking spoon!",
                                   description: "In this task the objective is to point to a big cooking spoon from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/9/bat.jpg",         null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/9/kuhaca.jpg",      null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/9/mala_kuhaca.png", null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/9/zlica.jpg",       null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_big_c_spoon.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          72,
                                   name:        "Show a big casserole!",
                                   description: "In this task the objective is to point to a big casserole from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/10/crveni_lonac.jpg",       null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/10/mali_plavi_lonac.png",   null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/10/pan.jpg",                null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/10/veliki_plavi_lonac.png", null, true),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/show_big_casserole.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          73,
                                   name:        "Show a big plate!",
                                   description: "In this task the objective is to point to a big plate from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/11/tanjur.png",   null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/11/m_tanjur.jpg", null, true),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/11/pan.jpg",      null, false),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/11/daska.jpg",    null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_big_plate.mp3"), "title")
                                   ),
                                   new ent::Task
                                   (
                                   id:          74,
                                   name:        "Show a big drinking glass!",
                                   description: "In this task the objective is to point to a big drinking glass from a set of four items.",
                                   thumbUrl:    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/TaskIcons/task-voice-commands-256x256.png"),
                                   type:        "#009",
                                   difficulty:   1,
                                   pictures:new List<ent::Picture.AnswerPicture>
                                                {
                                                    new ent::Picture.AnswerPicture(130, @"Resources/Images/VoiceCommands/Show_size/12/vrč.jpg",        null, false),
                                                    new ent::Picture.AnswerPicture(131, @"Resources/Images/VoiceCommands/Show_size/12/casa.png",       null, false),
                                                    new ent::Picture.AnswerPicture(132, @"Resources/Images/VoiceCommands/Show_size/12/v_casa.jpg",     null, true),
                                                    new ent::Picture.AnswerPicture(133, @"Resources/Images/VoiceCommands/Show_size/12/zuta_salica.png",null, false),
                                                },
                                   voiceCommand:new ent::Sound(1, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources/Sounds/Task_sound/Show_size/s_big_drinking_glass.mp3"), "title")
                                   ),
                               }),

                    }.ToList();
        }
    }
}
