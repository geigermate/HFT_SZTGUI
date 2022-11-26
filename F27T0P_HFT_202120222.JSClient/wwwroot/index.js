fetch('http://localhost:42137/brand')
    .then(x => x.json())
    .then(y => console.log(y));