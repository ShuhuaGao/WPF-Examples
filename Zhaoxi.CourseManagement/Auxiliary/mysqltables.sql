/*** CREATE the tables ***/

USE `zxdata`
;
/****** Object:  Table `course_teacher_relation`    Script Date: 2020/10/13 8:50:30 ******/


CREATE TABLE `course_teacher_relation`(
	`course_id` varchar(20) NOT NULL,
	`teacher_id` varchar(20) NOT NULL
)
;
/****** Object:  Table `courses`    Script Date: 2020/10/13 8:50:30 ******/


CREATE TABLE `courses`(
	`course_id` varchar(20) NOT NULL,
	`course_name` varchar(150) NOT NULL,
	`description` varchar(500) NULL,
	`is_publish` int NOT NULL,
	`course_cover` varchar(200) NOT NULL,
	`course_url` varchar(200) NOT NULL
)
;
/****** Object:  Table `platforms`    Script Date: 2020/10/13 8:50:30 ******/


CREATE TABLE `platforms`(
	`platform_id` varchar(20) NOT NULL,
	`platform_name` varchar(50) NOT NULL,
	`is_validation` int NOT NULL
)
;
/****** Object:  Table `play_record`    Script Date: 2020/10/13 8:50:30 ******/


CREATE TABLE `play_record`(
	`course_id` varchar(20) NOT NULL,
	`platform_id` varchar(20) NOT NULL,
	`play_count` decimal(18, 0) NOT NULL,
	`is_growing` int NOT NULL,
	`growing_rate` decimal(18, 0) NULL
)
;
/****** Object:  Table `users`    Script Date: 2020/10/13 8:50:30 ******/


CREATE TABLE `users`(
	`user_id` varchar(20) NOT NULL,
	`user_name` varchar(20) NOT NULL,
	`real_name` varchar(20) NOT NULL,
	`password` varchar(40) NULL,
	`is_validation` int NOT NULL,
	`is_can_login` int NOT NULL,
	`is_teacher` int NOT NULL,
	`avatar` varchar(200) NULL,
	`gender` int NULL
)
;

ALTER TABLE courses MODIFY COLUMN course_cover varchar(200) NOT NULL DEFAULT '';
ALTER TABLE courses MODIFY COLUMN course_url varchar(200) NOT NULL DEFAULT '';
