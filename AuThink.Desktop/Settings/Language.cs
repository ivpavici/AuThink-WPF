﻿namespace AuThink.Desktop.Settings
{
    public static class Language
    { 
        public static class Mainpage
        {
            public static string MainMenuContent()
            {
                return 
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Glavni izbornik" : "Main menu";
            }

            public static string PlayButtonContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Igraj" : "Play";
            }

            public static string SettingsButtonContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Postavke" : "Settings";
            }

            public static string AboutButtonContent()
            {
                return 
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "O nama" : "About";
            }

            public static string BackButtonContent()
            {
                return 
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Natrag" : "Back";
            }
        }

        public static class ChildrenPage
        {
            public static string FirstNameContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Ime:" : "First Name:";
            }

            public static string LastNameContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Prezime:" : "Last Name:";
            }
        }

        public static class TestListPage
        {
            public static string SelectTestButtonContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Izaberi test" : "Select test";
            }

            public static string GoBackButtonContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Natrag" : "Back";
            }
        }

        public static class EndTestPage
        {
            public static string SuccessfullTextContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Završen test!" : "Test completed!";
            }

            public static string ResetTestButtonContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Ponovi test" : "Restart test";
            }

            public static string TestMenuButtonContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Meni testova" : "Test menu";
            }

            public static string ExitButtonContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Izlaz" : "Exit";
            }
        }

        public static class SettingsPage
        {
            public static class Language
            {
                public static string Croatian()
                {
                    return
                        AuThink.Desktop.Properties.Settings.Default.Language == "Hr"
                            ? "Hrvatski"
                            : "Croatian";
                }

                public static string English()
                {
                    return
                        AuThink.Desktop.Properties.Settings.Default.Language == "Hr"
                            ? "Engleski"
                            : "English";
                }
            }

            public static string ChooseLanText()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Odaberite jezik:" : "Choose language:";
            }

            public static string SettingsText()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Postavke" : "Settings";
            }
            public static string RewardSoundText()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Nagradni zvuk:" : "Reward sound:";
            }
            public static string InstructionSoundText()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Glasovne upute:" : "Voice instructions:";
            }
            public static string SoundButtonContentOn()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Ukljuci" : "On";
            }
            public static string SoundButtonContentOff()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Iskljuci" : "Off";
            }
            public static string BackButtonContent()
            {
                return 
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Natrag" : "Back";
            }
            
        }

        public static class RewardPage
        {
            public static string ContinueButtonContent()
            {
                return
                    AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Nastavi" : "Continue";
            }

            public static string RewardTextContent()
            {
                return
                   AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Bravo!" : "Good job!";
            }
        }

        public static class PausePopup
        {
            public static string MainMenuButtonContent()
            {
                return
                  AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Glavni izbornik" : "Main menu";
            }

            public static string TestListButtonContent()
            {
                return
                  AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Testovi" : "Tests";
            }

            public static string SettingsButtonContent()
            {
                return
                  AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Postavke" : "Settings";
            }

            public static string ExitButtonContent()
            {
                return
                  AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Izlaz" : "Exit";
            }

            public static string ClosePopupButtonContent()
            {
                return
                  AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Nastavi" : "Continue";
            }
        }

        public static class AboutPage
        {
            public static string AboutTextContent()
            {
                return
                  AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "AuThink lite je demo verzija aplikacije kojoj je cilj pokazati osnovne funkcionalnosti sustava. Kasnije biti dostupna sa punom funkcionalnosti modificiranja danih zadataka." +
                                                                                             " \n\nMi smo tim studenata iz Splita, " +
                                                                                             "koji su započeli sa radom na projektu za Imagine Cup natjecanje. Odlučni za nastavak rada i unaprijeđivanje aplikacije koliko god to bude moguće!" +
                                                                                             " Svi trenutni zadaci i testovi su izrađeni u suradnji sa Centrom za autizam u Splitu. " +
                                                                                             "\n\nZa više detalja" +
                                                                                             " vezanih uz AuThink, našu viziju te dodatne informacije možete posjetiti našu web stranicu: www.authink.org ! \n\nKontaktirajte nas slobodno ukoliko imate bilo kakvih prijedloga!" +
                                                                                             " \n\nBilo bi nam drago čuti vaše mišljenje: info@authink.org :)"
                                                                                             :
                                                                                             "AuThink lite is a demo version of an app that will later be available with full funcionality. " +
                                                                                             "\n\nWe are a team of students from Croatia, who started working on this as an Imagine Cup project, but are determined to work further and improve it as much as possible! " +
                                                                                             "The idea is to demonstrate the basic funcionality of the AuThink system. We will enable task customization and individualization later on. " +
                                                                                             "All current tasks and tests were created in cooperation with the Centre for autism in Split, Croatia." +
                                                                                             "\n\nYou can visit our website: www.authink.org for more information and details about our project and vision! Please contact us if you have any suggestions concerning the app! " +
                                                                                             "\n\nWe would like to hear from you: info@authink.com :)"
                                                                                             ;
            }

            public static string BackButtonContent()
            {
                return
                  AuThink.Desktop.Properties.Settings.Default.Language == "Hr" ? "Natrag" : "Back";
            }
        }
    }
}
