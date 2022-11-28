SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";

DROP DATABASE IF EXISTS defilecture;
CREATE DATABASE defilecture;

USE defilecture;

--
-- Base de données : `defilecture`
--

-- --------------------------------------------------------

--
-- Structure de la table `compte`
--
DROP TABLE IF EXISTS `compte`;
CREATE TABLE `compte` (
  `ID_COMPTE` int(10) NOT NULL ,
  `ID_EQUIPE` int(10) DEFAULT NULL,
  `COURRIEL` varchar(255) NOT NULL,
  `MOT_PASSE` varchar(64) NOT NULL,
  `NOM` varchar(255) NOT NULL,
  `PRENOM` varchar(255) NOT NULL,
  `POINT` int(10) DEFAULT 0,
  `PROGRAMME_ETUDE` varchar(255) DEFAULT NULL,
  `AVATAR` varchar(255) NULL,
  `PSEUDONYME` varchar(255) DEFAULT NULL,
  `ROLE` int(10) NOT NULL DEFAULT 1,
  `DEVENIR_CAPITAINE` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`ID_COMPTE`),
  UNIQUE KEY `COURRIEL_UNQ` (`COURRIEL`),
  UNIQUE KEY `COMPTE_UNQ` (`PSEUDONYME`),
  KEY `ID_EQUIPE` (`ID_EQUIPE`)
  ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Structure de la table `equipe`
--

DROP TABLE IF EXISTS `equipe`;
CREATE TABLE `equipe` (
  `ID_EQUIPE` int(10) AUTO_INCREMENT NOT NULL,
  `NOM` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `POINT`INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`ID_EQUIPE`),
  UNIQUE KEY `NOM` (`NOM`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Structure de la table `demande_equipe`
--

DROP TABLE IF EXISTS `demande_equipe`;
CREATE TABLE `demande_equipe` (
  `ID_DEMANDE_EQUIPE` int(10) AUTO_INCREMENT NOT NULL,
  `ID_COMPTE` int(10) NOT NULL,
  `ID_EQUIPE` int(10) NOT NULL,
  `POINT` int(10) NOT NULL DEFAULT '0',
  `STATUT_DEMANDE` int(10) NOT NULL DEFAULT '-1',
  PRIMARY KEY (`ID_DEMANDE_EQUIPE`),
  KEY `ID_COMPTE` (`ID_COMPTE`),
  KEY `ID_EQUIPE` (`ID_EQUIPE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Structure de la table `defi`
--

DROP TABLE IF EXISTS `defi`;
CREATE TABLE `defi` (
  `ID_DEFI` int(10) AUTO_INCREMENT NOT NULL ,
  `ID_COMPTE` int(10) DEFAULT NULL,
  `NOM` varchar(255) NOT NULL,
  `DESCRIPTION` text DEFAULT NULL,
  `DATE_DEBUT` datetime(2) NOT NULL,
  `DATE_FIN` datetime(2) NOT NULL,
  `QUESTION` varchar(1024) DEFAULT NULL,
  `CHOIX_REPONSE_A` varchar(255) DEFAULT NULL,
  `CHOIX_REPONSE_B` varchar(255) DEFAULT NULL,
  `CHOIX_REPONSE_C` varchar(255) DEFAULT NULL,
  `CHOIX_REPONSE_D` varchar(255) DEFAULT NULL,
  `VALEUR_MINUTE` int(10) DEFAULT NULL,
  PRIMARY KEY (`ID_DEFI`),
  KEY `ID_COMPTE_FK` (`ID_COMPTE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Structure de la table `defi_reponse`
--

DROP TABLE IF EXISTS `defi_reponse`;
CREATE TABLE `defi_reponse` (
  `ID_DEFI_REPONSE` int(10) AUTO_INCREMENT NOT NULL ,
  `ID_DEFI` int(10) NOT NULL ,
  `REPONSE` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID_DEFI_REPONSE`),
  KEY `ID_DEFI_FK` (`ID_DEFI`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Structure de la table `inscription_defi`
--

DROP TABLE IF EXISTS `inscription_defi`;
CREATE TABLE `inscription_defi` (
  `ID_INSCRIPTION_DEFI` int(10) AUTO_INCREMENT NOT NULL,
  `ID_COMPTE` int(10) NOT NULL,
  `ID_DEFI` int(10) DEFAULT NULL,
  `EST_REUSSI` int(10) DEFAULT '0',
  `VALEUR_MINUTE` int(11) DEFAULT '0',
  `DATE_INSCRIPTION` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID_INSCRIPTION_DEFI`),
  KEY `ID_COMPTE` (`ID_COMPTE`),
  KEY `ID_DEFI` (`ID_DEFI`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Structure de la table `lecture`
--

DROP TABLE IF EXISTS `lecture`;
CREATE TABLE `lecture` (
  `ID_LECTURE` int(10) AUTO_INCREMENT NOT NULL,
  `ID_COMPTE` int(10) NOT NULL,
  `TITRE` varchar(255) NOT NULL,
  `DATE_INSCRIPTION` varchar(255) NOT NULL,
  `DUREE_MINUTES` int(10) NOT NULL,
  `EST_OBLIGATOIRE` tinyint(1),
  PRIMARY KEY (`ID_LECTURE`),
  KEY `ID_COMPTE` (`ID_COMPTE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `compte`
--

--
-- Vider la table, sans la supprimer, avant d'insérer dans `compte`
--
TRUNCATE TABLE `compte`;

INSERT INTO `compte` (`ID_COMPTE`, `ID_EQUIPE`, `PSEUDONYME`, `ROLE`, `PRENOM`, `NOM`, `COURRIEL`, `MOT_PASSE`, `PROGRAMME_ETUDE`, `POINT`, `AVATAR`, `DEVENIR_CAPITAINE`) VALUES
(1, NULL, 'ptrinkwon0', 3, 'Phoebe', 'Trinkwon', 'pt@gmail.com', 'WH2eUe8os0k', 'administration', 0, NULL, 0 ),
(2, NULL, 'emerrigans1', 3, 'Erhart', 'Merrigans', 'emer@gmail.com', '1mkf2OZnO04', 'administration', 0, NULL, 0 ),
(3, NULL, 'bpremble2', 3, 'Bertie', 'Premble', 'bpre@gmail.com', '0ewiD5', 'administration', 0, NULL, 0 ),
(4, 2, 'sgreatrakes3', 2, 'Sonnie', 'Greatrakes', 'sogre@gmail.com', 'Re0cNQ894', 'Informatique', 0, NULL, 0 ),
(5, 2, 'vpickover4', 1, 'Vina', 'Pickover', 'vinpi@gmail.com', 'YMc6EKovN', 'Sciences Humaines', 0, NULL, 0 ),
(6, 2, 'stuplin5', 4, 'Stephanie', 'Tuplin', 'stephtuplin@gmail.com', 'UAdz7XS', 'Sciences Humaines', 0, NULL, 0 ),
(7, 3, 'ahusher6', 2, 'Ashely', 'Husher', 'ash@gmail.com', 'sFzZ8n3B4EOa', 'Informatique', 0, NULL, 0),
(8, 3, 'kkees7', 1, 'Karena', 'Kees', 'kar98@gmail.com', 'x380sCU8Yp5J', 'Chimie Physique', 0, NULL, 0),
(9, 4, 'bwrefford8', 2, 'Bonnee', 'Wrefford', 'borwe@gmail.com', 'fIimk1dm', 'Chimie Physique', 0, NULL, 0 ),
(10, 5, 'acowey9', 2, 'Ashly', 'Cowey', 'asco@gmail.com', 'QJ9GEz', 'Chimie Physique', 0, NULL, '0' ),
(11, 5, 'hcritcharda', 1, 'Helen', 'Critchard', 'hecrit@gmail.com', 'iP8yrn', 'Reseautique', 0, NULL, 0),
(12, 6, 'dkenerb', 2, 'Donnamarie', 'Kener', 'donnamarie@gmail.com', 'WZCgLHFU', 'Reseautique', 0, NULL, 0 ),
(13, 7, 'klardezc', 2, 'Krystal', 'Lardez', 'krystal@gmail.com', 'XdGYMppF7cH', 'Science Nat', 0,NULL, 0 ),
(14, 8, 'domarkeyd', 2, 'Davidde', 'O'' Markey', 'markey@gmail.com', 'LKsp4AZ', 'Science Nat', 0, NULL, 0),
(15, NULL, 'tspoonere', 1, 'Tobiah', 'Spooner', 'tobi@gmail.com', 'Tobi', 'Administration', 0, NULL, 0);

--
-- Déchargement des données de la table `lecture`
--

--
-- Vider la table, sans la supprimer, avant d'insérer dans `lecture`
--
TRUNCATE TABLE `lecture`;
INSERT INTO `lecture` (`ID_LECTURE`,`ID_COMPTE`,`TITRE`, `DATE_INSCRIPTION`, `DUREE_MINUTES`, `EST_OBLIGATOIRE` ) VALUES
(1,1,'Tartuffle', '2022-07-04', 30, 0),
(2,1,'Cyrano', '2022-07-11', 30, 0),
(3,1,'John Jones', '2022-08-13', 30, 0),
(4,2,'BAKI', '2022-09-05', 30, 0),
(5,2,'Tartuffle', '2022-10-12', 30, 0),
(6,2,'Alchimiste', '2022-11-28', 30, 0),
(7,15,'Alchimiste', '2022-12-27', 30, 0),
(8,15,'Tartuffle', '2022-06-23', 30, 0),
(9,15,'Alchimiste', '2022-04-10', 30, 0),
(10,15,'Le Joueur', '2022-09-16', 30, 0),
(11,15,'Tartuffle', '2022-00-14', 30, 0);

--
-- Déchargement des données de la table `equipe`
--

--
-- Vider la table, sans la supprimer, avant d'insérer dans `equipe`
--
TRUNCATE TABLE `equipe`;
INSERT INTO `equipe` (`ID_EQUIPE`, `NOM`, `POINT`) VALUES
(1,'Chapeau de Paille', 0),
(2,'Bandits De Posséidon', 0),
(3,'Les Corsaires du Corbeau Noir', 0),
(4,'Les Pillards de la Mer du Sud', 0),
(5,'Les Raiders de l\'Anse Cachée', 0),
(6,'Les Sirènes', 0),
(7,'Les Bandanas Barbares', 0),
(8,'Les Âmes Amères', 0);

--
-- Déchargement des données de la table `demande_equipe`
--

--
-- Vider la table, sans la supprimer, avant d'insérer dans `demande_equipe`
--
TRUNCATE TABLE `demande_equipe`;
INSERT INTO `demande_equipe` (`ID_DEMANDE_EQUIPE`, `ID_COMPTE`, `ID_EQUIPE`, `POINT`, `STATUT_DEMANDE`) VALUES
( 1, 15, 1, 0, 1),
( 2, 1, 1, 0, 1),
( 3, 2, 1, 0, 1),
( 8, 3, 1, 0, 1);

--
--  Contraintes pour la table `compte`
--
ALTER TABLE `compte`
  ADD CONSTRAINT `COMPTE_FK1` FOREIGN KEY (`ID_EQUIPE`) REFERENCES `equipe` (`ID_EQUIPE`) ON DELETE SET NULL;

--
-- Contraintes pour la table `defi`
--
ALTER TABLE `defi`
  ADD CONSTRAINT `DEFI_FK1` FOREIGN KEY (`ID_COMPTE`) REFERENCES `compte` (`ID_COMPTE`) ON DELETE SET NULL;

--
-- Contraintes pour la table `demande_equipe`
--
ALTER TABLE `demande_equipe`
  ADD CONSTRAINT `DEMANDE_EQUIPE_FK1` FOREIGN KEY (`ID_COMPTE`) REFERENCES `compte` (`ID_COMPTE`) ON DELETE CASCADE,
  ADD CONSTRAINT `DEMANDE_EQUIPE_FK2` FOREIGN KEY (`ID_EQUIPE`) REFERENCES `equipe` (`ID_EQUIPE`) ON DELETE CASCADE;

--
-- Contraintes pour la table `lecture`
--
ALTER TABLE `lecture`
  ADD CONSTRAINT `LECTURE_FK1` FOREIGN KEY (`ID_COMPTE`) REFERENCES `compte` (`ID_COMPTE`) ON DELETE CASCADE;
  
--
-- Contraintes pour la table `defi_reponse`
--  
ALTER TABLE `defi_reponse`
  ADD CONSTRAINT `DEFI_REPONSE_FK1` FOREIGN KEY (`ID_DEFI`) REFERENCES `defi` (`ID_DEFI`) ON DELETE CASCADE;

