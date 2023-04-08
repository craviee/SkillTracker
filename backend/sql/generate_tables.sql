create table users
(
    Id         int auto_increment
        primary key,
    Created_At datetime   default CURRENT_TIMESTAMP not null,
    Email      varchar(255)                         not null,
    Name       varchar(255)                         not null,
    Role       int        default 1                 not null,
    Updated_At datetime                             null,
    Is_Enabled tinyint(1) default 1                 not null,
    constraint Users_email_unique
        unique (Email)
);

create table `groups`
(
    Id         int auto_increment
        primary key,
    Name       varchar(255)                       not null,
    Created_By int                                not null,
    Created_At datetime default CURRENT_TIMESTAMP null,
    Updated_By int                                not null,
    Updated_At datetime                           null,
    constraint groups_users_created_fk
        foreign key (Created_By) references users (Id),
    constraint groups_users_updated_fk
        foreign key (Updated_By) references users (Id)
);

create table skills
(
    Id         int auto_increment
        primary key,
    Group_Id   int                                not null,
    Name       varchar(255)                       not null,
    Created_By int                                not null,
    Created_At datetime default CURRENT_TIMESTAMP not null,
    Updated_By int                                null,
    Updated_At datetime                           null,
    constraint Skills_groups_Id_fk
        foreign key (Group_Id) references `groups` (Id),
    constraint Skills_users_created_fk
        foreign key (Created_By) references users (Id),
    constraint Skills_users_updated_fk
        foreign key (Updated_By) references users (Id)
);

create table userskills
(
    Id         int auto_increment
        primary key,
    User_Id    int                                not null,
    Skill_Id   int                                not null,
    Rate       int                                not null,
    Created_At datetime default CURRENT_TIMESTAMP not null,
    constraint UserSkills_skills_fk
        foreign key (Skill_Id) references skills (Id),
    constraint UserSkills_users_fk
        foreign key (User_Id) references users (Id)
);

create trigger TR_UPDATE_DATE_USER_DELETE
    after delete
    on userskills
    for each row
BEGIN
        Update skilltracker.users Set Updated_At = CURRENT_TIMESTAMP Where Id = OLD.User_Id;
    END;

create trigger TR_UPDATE_DATE_USER_INSERT
    after insert
    on userskills
    for each row
BEGIN
        Update skilltracker.users Set Updated_At = NEW.Created_At Where Id = NEW.User_Id;
    END;


