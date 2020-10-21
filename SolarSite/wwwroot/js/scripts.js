
        fetch(url = 'http://localhost:50719/api/Inverters')
            .then(response => {
                response.json()
            }
            )
            .then(data => {
                console.log(data)
            }
            ) // Work with JSON data here
  .catch((err) => {
            // Do something for an error here
        })

