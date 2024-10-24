SELECT Pedido.PedidoId, Produto.CodigoProduto, Produto.DescricaoProduto, PedidosItens.Quantidade 
FROM Pedido
INNER JOIN
	PedidosItens ON Pedido.PedidoId = PedidosItens.PedidoId
		INNER JOIN
			Produto ON Produto.ProdutoId = PedidosItens.ProdutosId
				WHERE Pedido.PedidoId = 25;




				

