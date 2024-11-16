  --ユーザーの作成
--ユーザーを切り替え
\c postgres


-- Project Name : TCTest
-- Date/Time    : 2024/11/16 16:22:55
-- Author       : es_win11_user
-- RDBMS Type   : PostgreSQL
-- Application  : A5:SQL Mk-2

/*
  << 注意！！ >>
  BackupToTempTable, RestoreFromTempTable疑似命令が付加されています。
  これにより、drop table, create table 後もデータが残ります。
  この機能は一時的に $$TableName のような一時テーブルを作成します。
  この機能は A5:SQL Mk-2でのみ有効であることに注意してください。
*/

-- ユーザ
-- * RestoreFromTempTable
create table user_info (
  user_id varchar(100)
  , name varchar(100) not null
  , age integer not null
  , constraint user_info_PKC primary key (user_id)
) ;

comment on table user_info is 'ユーザ';
comment on column user_info.user_id is 'ユーザID';
comment on column user_info.name is '氏名';
comment on column user_info.age is '年齢';



insert into public.user_info(user_id,name,age) values 
    ('USER01','Test太郎',20);
