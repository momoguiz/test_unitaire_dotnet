Diplome TSSR = new Diplome { Code = "TSSR", Nom = "Technicien Supérieur Systèmes et Réseaux", Niveau = 5 };
Diplome D2WM = new Diplome { Code = "D2WM", Nom = "Développeur Web et Web Mobile", Niveau = 5 };
Diplome ASR = new Diplome { Code = "ASR", Nom = "Administrateur Système et Réseau", Niveau = 6 };
Diplome CDA = new Diplome { Code = "CDA", Nom = "Concepteur Développeur d'Applications", Niveau = 6 };
Diplome ESD = new Diplome { Code = "ESD", Nom = "Expert en Sécurité Digitale", Niveau = 7 };
Diplome MS2D = new Diplome { Code = "MS2D", Nom = "Manager de Solutions Digitales et Data", Niveau = 7 };
Context.Diplomes.Add(TSSR);
Context.Diplomes.Add(D2WM);
Context.Diplomes.Add(ASR);
Context.Diplomes.Add(CDA);
Context.Diplomes.Add(ESD);
Context.Diplomes.Add(MS2D);

Promotion NCDA_006 = new Promotion { Id = 1, Nom = "NCDA_006", Debut = DateTime.Parse("07/10/2019", new CultureInfo("fr-FR")), Fin = DateTime.Parse("27/08/2021", new CultureInfo("fr-FR")), Diplome = CDA };
Promotion NCDA_007 = new Promotion { Id = 2, Nom = "NCDA_007", Debut = DateTime.Parse("12/10/2020", new CultureInfo("fr-FR")), Fin = DateTime.Parse("26/08/2022", new CultureInfo("fr-FR")), Diplome = CDA };
Promotion NCDA_008 = new Promotion { Id = 3, Nom = "NCDA_008", Debut = DateTime.Parse("11/10/2021", new CultureInfo("fr-FR")), Fin = DateTime.Parse("14/07/2023", new CultureInfo("fr-FR")), Diplome = CDA };
Promotion NASR_008 = new Promotion { Id = 4, Nom = "NASR_008", Debut = DateTime.Parse("11/10/2021", new CultureInfo("fr-FR")), Fin = DateTime.Parse("14/07/2023", new CultureInfo("fr-FR")), Diplome = ASR };
Promotion MS2D_001 = new Promotion { Id = 5, Nom = "MS2D_001", Debut = DateTime.Parse("11/10/2021", new CultureInfo("fr-FR")), Fin = DateTime.Parse("15/10/2022", new CultureInfo("fr-FR")), Diplome = MS2D };
Promotion NESD_001 = new Promotion { Id = 6, Nom = "NESD_001", Debut = DateTime.Parse("04/10/2021", new CultureInfo("fr-FR")), Fin = DateTime.Parse("07/10/2022", new CultureInfo("fr-FR")), Diplome = ESD };
Context.Promotions.Add(NCDA_006);
Context.Promotions.Add(NCDA_007);
Context.Promotions.Add(NCDA_008);
Context.Promotions.Add(NASR_008);
Context.Promotions.Add(MS2D_001);
Context.Promotions.Add(NESD_001);

Eleve AMARTIN = new Eleve { Id = 1, Nom = "MARTIN", Prenom = "Alexis", Adresse = "19 avenue Léo Lagrange", CodePostal = "79000", Ville = "Niort", Email="amartin@email.fr" };
Eleve CDUPONT = new Eleve { Id = 2, Nom = "DUPONT", Prenom = "Claire", Adresse = "2 avenue de Limoges", CodePostal = "79000", Ville = "Niort", Email = "cdupont@email.fr" };
Eleve AAUBIN = new Eleve { Id = 3, Nom = "AUBIN", Prenom = "Adèle", Adresse = "6 rue Alphonse Farault", CodePostal = "79000", Ville = "Niort", Email = "aaubin@email.fr" };
Eleve GCOLLIN = new Eleve { Id = 4, Nom = "COLLIN", Prenom = "Grégoire", Adresse = "18 rue de l'Hôtel de ville", CodePostal = "79180", Ville = "Chauray", Email = "gcollin@email.fr" };
Eleve IBOISVERT = new Eleve { Id = 5, Nom = "BOISVERT", Prenom = "Isabelle", Adresse = "352 avenue de La Rochelle", CodePostal = "79000", Ville = "Niort", Email = "iboisvert@email.fr" };
Eleve YMIRON = new Eleve { Id = 6, Nom = "MIRON", Prenom = "Yvan", Adresse = "6 rue de la ferme", CodePostal = "79450", Ville = "Saint-Aubin-le-Cloud", Email = "ymiron@email.fr" };
Eleve MLETOURNEAU = new Eleve { Id = 7, Nom = "LETOURNEAU", Prenom = "Margaux", Adresse = "12 rue de l'ancienne Poudrière", CodePostal = "79000", Ville = "Bessines", Email = "mletourneau@email.fr" };

Context.Eleves.Add(AMARTIN);
Context.Eleves.Add(CDUPONT);
Context.Eleves.Add(AAUBIN);
Context.Eleves.Add(GCOLLIN);
Context.Eleves.Add(IBOISVERT);
Context.Eleves.Add(YMIRON);
Context.Eleves.Add(MLETOURNEAU);

NCDA_007.Eleves.Add(AMARTIN);
NCDA_007.Eleves.Add(CDUPONT);
NCDA_008.Eleves.Add(AAUBIN);
NCDA_008.Eleves.Add(GCOLLIN);
NCDA_008.Eleves.Add(IBOISVERT);
NESD_001.Eleves.Add(YMIRON);
MS2D_001.Eleves.Add(MLETOURNEAU);