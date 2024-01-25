process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = 0;

let url = "https://localhost:7014";

let headers = new Headers();
headers.append("Content-Type", "application/json; charset=utf-8");

fetch(new Request(url + "/api/stud/getall"),
    {
        method: "GET",
        headers: headers,
        credentials: "include"
    })
    .then((response) => response.json())
    .then(function (data) {
        console.log(data);
    })
    .catch((err) => console.log(err));
