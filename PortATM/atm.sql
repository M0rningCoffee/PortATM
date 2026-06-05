-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 05/06/2026 às 16:18
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `atm`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `contas`
--

CREATE TABLE `contas` (
  `id_conta` int(11) NOT NULL,
  `cpf` varchar(14) NOT NULL,
  `nome completo` varchar(20) NOT NULL,
  `Genero` varchar(10) NOT NULL,
  `aniversario` varchar(10) NOT NULL,
  `saldo` float DEFAULT 0,
  `cartao` int(11) NOT NULL,
  `pin` int(11) NOT NULL,
  `agencia` varchar(6) NOT NULL,
  `cc` varchar(7) NOT NULL,
  `pix` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `contas`
--

INSERT INTO `contas` (`id_conta`, `cpf`, `nome completo`, `Genero`, `aniversario`, `saldo`, `cartao`, `pin`, `agencia`, `cc`, `pix`) VALUES
(1, '111.111.111-11', 'eric', '', '', 0.9, 123456, 123, '1110', '11110', 1),
(13, 'CPF', 'gabriel', 'Male', '2026-06-05', 0, 8908, 76789, '90', '', 0),
(1234, '123', 'eric teste', 'Male', '2026-06-05', 0, 467898, 1232, '', '', 0);

-- --------------------------------------------------------

--
-- Estrutura para tabela `registros`
--

CREATE TABLE `registros` (
  `id_registros` int(11) NOT NULL,
  `data` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `id_conta_to` int(11) NOT NULL,
  `id_conta_from` int(11) NOT NULL,
  `operacao` varchar(64) DEFAULT NULL CHECK (`operacao` = 'pix' or `operacao` = 'transferência' or `operacao` = 'saque' or `operacao` = 'depósito'),
  `valor` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `registros`
--

INSERT INTO `registros` (`id_registros`, `data`, `id_conta_to`, `id_conta_from`, `operacao`, `valor`) VALUES
(1, '2026-06-04 22:48:13', 1, 1, 'depósito', 0),
(2, '2026-06-04 22:52:25', 1, 1, 'Saque', 0.1),
(3, '2026-06-04 22:52:57', 1, 1, 'Saque', 9);

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `contas`
--
ALTER TABLE `contas`
  ADD PRIMARY KEY (`id_conta`);

--
-- Índices de tabela `registros`
--
ALTER TABLE `registros`
  ADD PRIMARY KEY (`id_registros`),
  ADD KEY `id_conta_to` (`id_conta_to`),
  ADD KEY `id_conta_from` (`id_conta_from`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `contas`
--
ALTER TABLE `contas`
  MODIFY `id_conta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49091;

--
-- AUTO_INCREMENT de tabela `registros`
--
ALTER TABLE `registros`
  MODIFY `id_registros` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `registros`
--
ALTER TABLE `registros`
  ADD CONSTRAINT `registros_ibfk_1` FOREIGN KEY (`id_conta_to`) REFERENCES `contas` (`id_conta`),
  ADD CONSTRAINT `registros_ibfk_2` FOREIGN KEY (`id_conta_from`) REFERENCES `contas` (`id_conta`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
