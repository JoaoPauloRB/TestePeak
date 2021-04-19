function findName () {
    var id = document.getElementById('id').value;
    fetch(`http://localhost:5000?id=${id}`, {
        method: 'GET',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        }
    })
    .then((response) => {
        if(!response.ok)
            throw response.json();
        return response.json();
    })
    .then(result => {
        document.getElementById('resultName').innerText = result.name;
    })
    .catch(reason => {
        reason.then(error => {
            document.getElementById('resultName').innerText = error.message;
        });
    });
}

function calcTotal() {
    var installments = document.getElementById('installments').value;
    var amount = document.getElementById('amount').value;
    fetch('http://localhost:5000', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ installments, amount })
    })
    .then((response) => {
        return response.json();
    })
    .then(result => {
        var currency = new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(result.total);
        document.getElementById('resultTotal').innerText = currency;
    });
}