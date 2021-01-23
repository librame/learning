/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50626
Source Host           : 127.0.0.1:3306
Source Database       : osms

Target Server Type    : MYSQL
Target Server Version : 50626
File Encoding         : 65001

Date: 2020-06-12 17:10:21
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for job_info
-- ----------------------------
DROP TABLE IF EXISTS `job_info`;
CREATE TABLE `job_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `en_code` varchar(32) DEFAULT NULL COMMENT '岗位编号',
  `job_name` varchar(64) DEFAULT NULL COMMENT '岗位名称',
  `org_id` int(11) DEFAULT NULL COMMENT '所在机构/部门/小组ID',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `is_delete` int(1) DEFAULT NULL COMMENT '是否删除：0=未删除，1=删除',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='岗位信息表';

-- ----------------------------
-- Records of job_info
-- ----------------------------

-- ----------------------------
-- Table structure for log_info
-- ----------------------------
DROP TABLE IF EXISTS `log_info`;
CREATE TABLE `log_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `user_id` int(11) DEFAULT NULL COMMENT '操作人ID',
  `opt_type` varchar(32) DEFAULT NULL COMMENT '操作类型',
  `opt_ip` varchar(32) DEFAULT NULL COMMENT '操作IP',
  `remark` varchar(255) DEFAULT NULL COMMENT '备注',
  `create_time` datetime DEFAULT NULL COMMENT '操作时间',
  `is_delete` int(1) DEFAULT NULL COMMENT '是否删除：0=未删除，1=删除',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log_info
-- ----------------------------

-- ----------------------------
-- Table structure for org_info
-- ----------------------------
DROP TABLE IF EXISTS `org_info`;
CREATE TABLE `org_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `parent_id` int(11) DEFAULT NULL COMMENT '父级ID',
  `org_type` int(1) DEFAULT NULL COMMENT '机构类型: 1=公司，2=部门，3=小组',
  `full_name` varchar(64) DEFAULT NULL COMMENT '机构名称',
  `en_code` varchar(32) DEFAULT NULL COMMENT '机构编号',
  `manager` varchar(32) DEFAULT NULL COMMENT '机构负责人',
  `mobile_phone` varchar(16) DEFAULT NULL COMMENT '联系电话',
  `email` varchar(32) DEFAULT NULL COMMENT '邮箱',
  `address` varchar(64) DEFAULT NULL COMMENT '联系地址',
  `remark` varchar(255) DEFAULT NULL COMMENT '备注信息',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `is_delete` int(1) DEFAULT NULL COMMENT '是否删除：0=未删除，1=删除',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='机构信息表';

-- ----------------------------
-- Records of org_info
-- ----------------------------

-- ----------------------------
-- Table structure for user_info
-- ----------------------------
DROP TABLE IF EXISTS `user_info`;
CREATE TABLE `user_info` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键ID',
  `account` varchar(32) DEFAULT NULL COMMENT '用户登录账号',
  `user_name` varchar(32) DEFAULT NULL COMMENT '用户姓名',
  `password` varchar(32) DEFAULT NULL COMMENT '登录密码',
  `is_admin` int(1) DEFAULT NULL COMMENT '用户类型：0=员工，1=管理员',
  `gender` varchar(4) DEFAULT NULL COMMENT '性别：男，女',
  `mobile_phone` varchar(16) DEFAULT NULL COMMENT '联系电话',
  `commpany_id` int(11) DEFAULT NULL COMMENT '公司ID',
  `dept_id` int(11) DEFAULT NULL COMMENT '部门ID',
  `job_id` int(11) DEFAULT NULL COMMENT '岗位ID',
  `is_allow` int(1) DEFAULT NULL COMMENT '是否允许登录：0=允许，1=不允许',
  `remark` varchar(255) DEFAULT NULL COMMENT '备注',
  `create_time` datetime DEFAULT NULL COMMENT '创建时间',
  `is_delete` int(1) DEFAULT NULL COMMENT '是否删除：0=未删除，1=删除',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户信息表';

-- ----------------------------
-- Records of user_info
-- ----------------------------


