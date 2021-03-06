/*
This script was created by Visual Studio on 2016-04-17 at 17:51.
Run this script on (localDB)\MSSQLLocalDB.EmptyDatabase (DESKTOP-2RBOND9\we_apon) to make it the same as (LocalDB)\MSSQLLocalDB.YetAnotherStoreDatabase (DESKTOP-2RBOND9\we_apon).
This script performs its actions in the following order:
1. Disable foreign-key constraints.
2. Perform DELETE commands. 
3. Perform UPDATE commands.
4. Perform INSERT commands.
5. Re-enable foreign-key constraints.
Please back up your target database before running this script.
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
/*Pointer used for text / image updates. This might not be needed, but is declared here just in case*/
DECLARE @pv binary(16)
BEGIN TRANSACTION
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_ClientOrder]
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'244c20b3-43c4-4c4c-8aa5-d261fca29e09', N'бйЭчйеи', N'ЗГОпЮвчЭнЮцЫЗАРхФьЪАсйЪалЦИеЗ', 1)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'44707e3f-f6a0-4017-aeb0-a79b2f151975', N'вшнМЧуГвьТхквЖНЗБсХПЖРзфз', N'ФвСЖтЩШФТюОгэртсСсЭаОьл', 0)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'48b448ae-4e0d-408d-8f8a-43c7351d3516', N'згПГНКХЛшь', N'ХюЛВеЖаъдъДаиЦ', 0)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'4c08c8b0-1bbe-41be-9a29-23ea63cecabe', N'ИЭиГнтШыъГцщтмефпдМГКШоИЕСОд', N'ижхМВънфЖсзТйИюЗЮГЫуЛмн', 1)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'4c6c45ce-5bb9-48c5-aa2a-7e697a6c721e', N'ЧДЛъКПЭЕЬюцЪввОюПУЖг', N'ЪДЛЖРоХьъпбщРымЖГЫЦХЪэрШЦЛ', 0)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'50ff28b9-e058-4520-b391-11d1ff5f6fa7', N'РсичэцДэтыЬЪдНЛфжЬРХ', N'дсфКПЛдмЩБЪыоВюЭДшИ', 0)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'5202382a-79f9-44cb-9c5b-5cdfc876a659', N'нЧдТТасЭЖышйТЗЦоцЖУъГ', N'СйюИаh gig i', 1)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'57c22279-1693-4eca-85d0-36388656d90d', N'тЫФыРЮБЫ', N'рьЮютЕэ', 1)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'6443e48c-399a-4911-8ede-988b45e45119', N'ЗСэЪбЩПЕггпЙагдЪзЪпцп', N'мАдаб', 1)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'6e796efc-4feb-4770-9513-5ee2a044da89', N'сбзжИДЪикЫХФЦКбфЗЧ', N'Упъьнт', 1)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'95598d40-8f4b-4c68-8daf-50cb2c829337', N'ЧнЖълиЫюпфqwe цчw  ', N'ФУдРНФрзчЪЙюРокds asd ', 1)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'a7ce9736-a1d4-47d9-ba32-ee515274361d', N'ЫзСоТ', N'НэаБХФыюСЙС', 0)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'c7b287ef-f2f5-4df4-b647-241a55b5f24d', N'еуЬфИнasd asdasd asd ', N'уКЦСМОсшЭЭУъдЬшщНоРХ', 0)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'fa904403-17fe-404d-8649-ca9275379803', N'хкЧукЬ', N'хгиИмгУДЖоизГТвксртдН', 0)
INSERT INTO [dbo].[Clients] ([Id], [Name], [Address], [VIP]) VALUES (N'fb353c49-9d03-4a73-bf79-0cf3fdeed93c', N'ьеНъэйШПъсХЛ', N'ъЬНуЖЗжПМшжРВоВтЦтэрфТзУБйт', 0)
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (1, N'ШУФВЧПгоШеЙциИонБмЮЕбЙЮшЧйЮ', N'5202382a-79f9-44cb-9c5b-5cdfc876a659')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (2, N'загшаДпнВХЪЦдтБбшЕ', N'5202382a-79f9-44cb-9c5b-5cdfc876a659')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (3, N'ЙПьыаЦСЭъЭмЙЗСцмдшеэщдЪпГЭжСШаЦ', N'5202382a-79f9-44cb-9c5b-5cdfc876a659')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (4, N'хЮхСХюу', N'5202382a-79f9-44cb-9c5b-5cdfc876a659')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (5, N'пююЛРЙСдзуфвЪАХГЫуНъйОлюР', N'5202382a-79f9-44cb-9c5b-5cdfc876a659')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (7, N'ЛффИоЦЦю', N'5202382a-79f9-44cb-9c5b-5cdfc876a659')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (9, N'зюЦЗЙЭПдЬнуВХоМЩбоцэзуЙЖа', N'5202382a-79f9-44cb-9c5b-5cdfc876a659')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (10, N'кАэшЮзАдзС', N'5202382a-79f9-44cb-9c5b-5cdfc876a659')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (11, N'зБжМшЦп', N'57c22279-1693-4eca-85d0-36388656d90d')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (12, N'СфЮщФЬЦйэЫншСйВР', N'244c20b3-43c4-4c4c-8aa5-d261fca29e09')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (13, N'пЙсЧгшчЩ', N'57c22279-1693-4eca-85d0-36388656d90d')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (14, N'оАТДшьй', N'57c22279-1693-4eca-85d0-36388656d90d')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (15, N' asd f', N'4c08c8b0-1bbe-41be-9a29-23ea63cecabe')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (16, N'нжЩхШпзыЙвжФ', N'4c08c8b0-1bbe-41be-9a29-23ea63cecabe')
INSERT INTO [dbo].[Orders] ([Number], [Description], [ClientId]) VALUES (17, N'нжЩхШпзыЙвжФ', N'4c08c8b0-1bbe-41be-9a29-23ea63cecabe')
SET IDENTITY_INSERT [dbo].[Orders] OFF
ALTER TABLE [dbo].[Orders]
    ADD CONSTRAINT [FK_ClientOrder] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id])
COMMIT TRANSACTION
