USE [master]
GO
/****** Object:  Database [PRN231SU22]    Script Date: 6/21/2022 11:57:36 PM ******/
CREATE DATABASE [PRN221_Project_Cinema]
GO
USE [PRN221_Project_Cinema]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 6/21/2022 11:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 6/21/2022 11:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Year] [int] NULL,
	[Image] NVARCHAR(255) NULL,
	[Description] ntext NULL,
	[GenreID] [int] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 6/21/2022 11:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](200) NULL,
	[Gender] [nvarchar](10) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](100) NULL,
	[Type] int NULL,
	[IsActive] BIT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rates]    Script Date: 6/21/2022 11:57:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rates](
	[MovieID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[Comment] [ntext] NULL,
	[NumericRating] [float] NULL,
	[Time] [datetime] NULL,
 CONSTRAINT [PK_Rates] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC,
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (28, N'Phim Hành Động')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (12, N'Phim Phiêu Lưu')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (16, N'Phim Hoạt Hình')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (35, N'Phim Hài')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (80, N'Phim Hình Sự')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (99, N'Phim Tài Liệu')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (18, N'Phim Chính Kịch')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (10751, N'Phim Gia Đình')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (14, N'Phim Giả Tượng')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (36, N'Phim Lịch Sử')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (27, N'Phim Kinh Dị')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (10402, N'Phim Nhạc')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (9648, N'Phim Bí Ẩn')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (10749, N'Phim Lãng Mạn')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (878, N'Phim Khoa Học Viễn Tưởng')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (10770, N'Chương Trình Truyền Hình')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (53, N'Phim Gây Cấn')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (10752, N'Phim Chiến Tranh')
INSERT [dbo].[Genres] ([GenreID], [Description]) VALUES (37, N'Phim Miền Tây')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (315162, N'Mèo Đi Hia: Điều Ước Cuối Cùng', 2022, 10751, '/dKjjVuPawiREBYjREb3U5SCtfrt.jpg', N'Puss phát hiện ra rằng niềm đam mê phiêu lưu mạo hiểm của anh đã gây ra hậu quả: Anh đã đốt cháy 8 trong số 9 mạng sống của mình, bây giờ chỉ còn lại đúng một mạng. Anh ta bắt đầu một cuộc hành trình để tìm Điều ước cuối cùng thần thoại trong Rừng Đen nhằm khôi phục lại chín mạng sống của mình. Chỉ còn một mạng sống, đây có lẽ sẽ là cuộc hành trình nguy hiểm nhất của Puss.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (505642, N'Chiến Binh Báo Đen: Wakanda Bất Diệt', 2022, 878, '/uLluouDdIqqtB5Yrvdvt8DzAEs6.jpg', N'Nữ hoàng Ramonda, Shuri, M’Baku, Okoye và Dora Milaje chiến đấu để bảo vệ quốc gia của họ khỏi sự can thiệp của các thế lực thế giới sau cái chết của Vua T’Challa. Khi người Wakanda cố gắng nắm bắt chương tiếp theo của họ, các anh hùng phải hợp tác với nhau với sự giúp đỡ của War Dog Nakia và Everett Ross và tạo ra một con đường mới cho vương quốc Wakanda.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (850871, N'Sayen Báo Thù', 2023, 53, '/aCy61aU7BMG7SfhkaAaasS0KzUO.jpg', N'Cô nàng Sayen đang săn lùng những kẻ đã sát hại bà của cô. Sử dụng sự đào tạo và kiến thức về tự nhiên của mình, cô ấy có thể lật ngược tình thế khi biết được âm mưu từ một tập đoàn đang đe dọa vùng đất tổ tiên của người dân cô ấy.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (631842, N'Tiếng Gõ Ở Căn Nhà Gỗ', 2023, 9648, '/9nq8ViDNUDM7GMAc0Shg7KsTP2Y.jpg', N'Trong một kỳ nghỉ, một bé gái và gia đình cô bị bắt làm con tin bởi những kẻ lạ mặt có vũ trang, những kẻ này yêu cầu họ phải đưa ra sự lựa chọn để ngăn chặn ngày tận thế.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (1026563, N'13 Nghi Thức Trừ Tà', 2022, 18, '/qMqYctlfKuua70xWApBXh5XN9PS.jpg', N'Sau hành vi kỳ lạ của thiếu niên Laura Villegas, gia đình cô đã gọi một chuyên gia trừ tà được Vatican phê chuẩn để can thiệp vào trường hợp bị quỷ ám. Từ đó hàng loạt hiện tượng kỳ lạ xuất hiện.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (785084, N'Cá Voi', 2022, 18, '/jQ0gylJMxWSL490sy0RrPj1Lj7e.jpg', N'Bộ phim xoay quanh Charlie, người mắc hội chứng rối loạn ăn uống sau tai nạn của người bạn đời, khiến cơ thể anh trở nên béo phì cùng cân nặng lên đến 600 pound (272 kg). Khi sức khỏe ngày càng xấu đi, anh cố gắng kết nối lại với cô con gái đã từng bị bỏ rơi của mình tên Ellie cũng như đấu tranh để tìm lại ý nghĩa cho cuộc sống.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (76600, N'Avatar:  Dòng Chảy Của Nước', 2022, 878, '/jGmC7aMqoLU0ALRKHkz3pQVV1pg.jpg', N'Câu chuyện của “Avatar: Dòng Chảy Của Nước” lấy bối cảnh 10 năm sau những sự kiện xảy ra ở phần đầu tiên. Phim kể câu chuyện về gia đình mới của Jake Sully (Sam Worthington thủ vai) cùng những rắc rối theo sau và bi kịch họ phải chịu đựng khi phe loài người xâm lược hành tinh Pandora.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (536554, N'M3GAN', 2022, 878, '/tpHng7ZPa6K2yHJI5aPgHSIPcvx.jpg', N'M3GAN là một điều kỳ diệu của trí tuệ nhân tạo, một con búp bê sống động như thật được lập trình để trở thành người bạn đồng hành tốt nhất của trẻ và cha mẹ. Được thiết kế bởi Gemma, một kỹ sư thiết kế người máy xuất sắc, M3GAN có thể nghe, xem và học hỏi trong suốt quá trình nó đóng vai trò là người bạn và người thầy, người đồng hành và người bảo vệ cho cả gia đình. Khi Gemma bất đắc dĩ trở thành người chăm sóc cho cô cháu gái 8 tuổi của mình, cô quyết định đưa cho cô bé một nguyên mẫu M3GAN, một quyết định dẫn đến một kết quả vượt ngoài mọi sự dự tính của cô.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (640146, N'Người Kiến và Chiến Binh Ong: Thế Giới Lượng Tử', 2023, 12, '/6UG4j6KSkJbmibnFmDBZJJ2DWWA.jpg', N'Scott Lang và Hope Van Dyne trở lại tiếp tục cuộc phiêu lưu của họ với vai trò Người Kiến và Chiến binh Ong. Cùng với cha mẹ của Hope, họ sẽ có chuyến khám phá Lượng Tử Giới, gặp gỡ những sinh vật mới lạ và bắt đầu cuộc hành trình vào thế giới lượng tử.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (758009, N'Ăn Cưới Gặp Ăn Cướp', 2022, 28, '/gNObfXTTfqX6oOxV7DUlyqVGc9R.jpg', N'Cặp đôi Darcy (Jennifer Lopez thủ vai) và Tom (Josh Duhamel thủ vai) mời cả gia đình và những người bạn thân thiết đến một hòn đảo tại Philippines để tham dự lễ cưới của cả hai. Những lo lắng, tranh cãi vụn vặt của Darcy và Tom khiến mối quan hệ của hai người rơi vào tình trạng “báo động” ngay trước hôn lễ. Và mọi chuyện trở nên tệ hại thực sự khi một băng cướp ập vào lễ cưới, bắt cóc tất cả khách mời làm con tin. Darcy và Tom phải cùng nhau đối đầu với băng cướp, để rồi nhận ra tình yêu của họ tuyệt vời đến nhường nào.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (436270, N'Black Adam', 2022, 14, '/oAT0oFl0GWeIjpo1WnF601GFpwm.jpg', N'Dwayne Johnson sẽ góp mặt trong tác phẩm hành động - phiêu lưu mới của New Line Cinema, mang tên BLACK ADAM. Đây là bộ phim đầu tiên trên màn ảnh rộng khai thác câu chuyện của siêu anh hùng DC này, dưới sự sáng tạo của đạo diễn Jaume Collet-Serra (đạo diễn của Jungle Cruise). Gần 5.000 năm sau khi bị cầm tù với quyền năng tối thượng từ những vị thần cổ đại, Black Adam (Dwayne Johnson) sẽ được giải phóng khỏi nấm mồ chết chóc của mình, mang tới thế giới hiện đại một kiểu nhận thức về công lý hoàn toàn mới.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (677179, N'Tay Đấm Huyền Thoại 3', 2023, 18, '/ruRw4sHNoMLtpdL7L63PYuiEwO1.jpg', N'Tay đấm lừng danh Adonis Creed, khi gặp gỡ một người bạn cũ, nhưng cũng đồng thời là đối thủ mới của anh, Anderson Dame. Cả hai từng có một quá khứ thân thiết, mà theo lời Creed nói, Dame “giống như gia đình của anh”. Tuy nhiên, một biến cố trong quá khứ xảy ra, đẩy Creed và Dame về hai đầu chiến tuyến. Giờ đây, khi đã trưởng thành, họ gặp lại nhau trên sàn đấu, để rồi trở thành những đối thủ “không đội trời chung”.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (804150, N'Gấu Điên', 2023, 53, '/7ceE6xsOlKOLDOvwLellfSr5hud.jpg', N'Trong một khu rừng ở Georgia, một con gấu đen Mỹ bất ngờ ăn phải lượng lớn chất kích thích bị rơi từ máy bay của những kẻ buôn lậu và điều này đã khiến nó trở nên điên loạn.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (1077280, N'Khi Hart Ra Tay', 2023, 35, '/1EnBjTJ5utgT1OXYBZ8YwByRCzP.jpg', N'Kevin Hart - thủ vai một phiên bản của chính anh ta - đang thực hiện nhiệm vụ bất chấp tử thần để trở thành một ngôi sao hành động. Và với một chút trợ giúp từ John Travolta, Nathalie Emmanuel và Josh Hartnett - anh ta có thể thành công hay không?')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (646389, N'Bay Vào Tử Địa', 2023, 28, '/i2xAwFZGTZudjdOxUvrCMyKi0sD.jpg', N'Sự cố sét đánh đã làm cho chuyến bay của cơ trưởng Brodie phụ trách rơi xuống quần đảo do phiến quân chiếm đóng. Cú rơi chỉ là sự khởi đầu cho những cơn ác mộng khi cơ trưởng buộc phải hợp tác với một kẻ sát nhân để giành lại mạng sống cho cả đoàn.')
INSERT [dbo].[Movies] ([MovieID], [Title], [Year], [GenreID], [Image], [Description]) VALUES (594767, N'Shazam! Cơn Thịnh Nộ Của Các Vị Thần', 2023, 14, '/67ztbGkhtltymsqElMnrfWujsY3.jpg', N'Bộ phim tiếp tục câu chuyện về cậu thiếu niên Billy Batson, khi đọc thuộc lòng từ ma thuật \"SHAZAM!\" được biến thành Siêu anh hùng thay thế bản ngã trưởng thành của anh ấy, Shazam.')
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password], [Type], [IsActive]) VALUES (1, N'Phạm Minh Hùng', N'Nam', N'hungpm@gmail.com', N'123', 1, 1)
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password], [Type], [IsActive]) VALUES (2, N'Phạm Ngọc Minh Châu', N'Nữ', N'chaupnm@gmail.com', N'1234', 2, 1)
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password], [Type], [IsActive]) VALUES (3, N'Hoàng Đức Hải', N'Nam', N'haihd@gmail.com', N'12345', 2, 1)
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password], [Type], [IsActive]) VALUES (4, N'Quách Như Thế', N'Nam', N'theqn@gmail.com', N'123456', 2, 1)
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password], [Type], [IsActive]) VALUES (5, N'Nguyễn Thùy Dương', N'Nữ', N'duongnt@gmail.com', N'1234567', 2, 1)
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password], [Type], [IsActive]) VALUES (6, N'Trịnh Thị Trang', N'Nữ', N'trangtt@gmail.com', N'12345678', 2, 1)
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password], [Type], [IsActive]) VALUES (7, N'Hoàng Tùng', N'Nam', N'tungh@gmail.com', N'123456789', 2, 1)
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password], [Type], [IsActive]) VALUES (8, N'Nguyễn Doãn Đạt', N'Nam', N'datndw@gmail.com', N'1', 2, 1)
INSERT [dbo].[Persons] ([PersonID], [Fullname], [Gender], [Email], [Password], [Type], [IsActive]) VALUES (9, N'Nguyễn Doãn Đạt', N'Nam', N'datnd27@fsoft.com.vn', N'1', 1, 1)
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
INSERT [dbo].[Rates] ([MovieID], [PersonID], [Comment], [NumericRating], [Time]) VALUES (315162, 1, N'Phim rất hay', 8.6, CAST(N'2022-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Rates] ([MovieID], [PersonID], [Comment], [NumericRating], [Time]) VALUES (315162, 2, N'Phim nên xem', 8.4, CAST(N'2022-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Rates] ([MovieID], [PersonID], [Comment], [NumericRating], [Time]) VALUES (677179, 1, N'Cái kết có hậu nha', 4.5, CAST(N'2022-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Rates] ([MovieID], [PersonID], [Comment], [NumericRating], [Time]) VALUES (436270, 1, N'Phim hơi chán', 3.6, CAST(N'2022-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Rates] ([MovieID], [PersonID], [Comment], [NumericRating], [Time]) VALUES (76600, 8, N'Web xem phim quá đỉnh nên cho 10 điểm, phim cũng được', 10, CAST(N'2022-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Rates] ([MovieID], [PersonID], [Comment], [NumericRating], [Time]) VALUES (594767, 8, N'Đang xem mà ngủ quên, không có sức hút', 3, CAST(N'2022-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Rates] ([MovieID], [PersonID], [Comment], [NumericRating], [Time]) VALUES (505642, 8, N'Nhà *** đến từ Châu Âu, mã mời: cinemahub, nhận ngay 1 củ :v inbox admin Phạm Quang Hưng', 9, CAST(N'2022-10-06T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres] FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genres] ([GenreID])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres]
GO
ALTER TABLE [dbo].[Rates]  WITH CHECK ADD  CONSTRAINT [FK_Rates_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Rates] CHECK CONSTRAINT [FK_Rates_Movies]
GO
ALTER TABLE [dbo].[Rates]  WITH CHECK ADD  CONSTRAINT [FK_Rates_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Rates] CHECK CONSTRAINT [FK_Rates_Persons]
