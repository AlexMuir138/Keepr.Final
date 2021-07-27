CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: Account id',
  name VARCHAR(255) NOT NULL COMMENT 'Keep Name',
  description VARCHAR(255) NOT NULL COMMENT 'Keep description',
  img VARCHAR(255) NOT NULL COMMENT 'Keep Image',
  views int COMMENT 'Keep View', 
  shares int COMMENT 'Keep Shares',
  keeps int COMMENT 'Keep Keeps',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) On DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vaults(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: Account id',
  name VARCHAR(255) NOT NULL COMMENT 'Vault Name',
  description VARCHAR(255) NOT NULL COMMENT 'Vault description',
  isPrivate TINYINT DEFAULT 0 COMMENT 'Private Setting',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) On DELETE CASCADE
)default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vault_keeps(
  id int NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: Account id',
  vaultId int NOT NULL COMMENT 'FK: Vault Id',
  keepId int NOT NULL COMMENT 'FK: Keep Id',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) On DELETE CASCADE,
  FOREIGN KEY (vaultId) REFERENCES vaults(id) On DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) On DELETE CASCADE
)default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS profiles(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

DROP TABLE keeps;
DROP TABLE accounts;
DROP TABLE vaults;
DROP Table vault_keeps;
SELECT * FROM keeps;
SELECT * FROM vaults;
SELECT * FROM vault_keeps;