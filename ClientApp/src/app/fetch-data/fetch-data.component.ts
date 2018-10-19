import { Component, Inject,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit{
  public Users;
  constructor(private http: HttpClient) { }
  ngOnInit(){
    this.GetAllUsers();
  }
  GetAllUsers(){
    this.http.get("api/Home/Allusers").subscribe(result => {
      console.log("getting all users");
      console.log(result);
      this.Users = result;
    }, error => console.error(error));
  }
  DeleteUser(id){
    console.log("============");
    console.log(id);
    console.log("============");
    this.http.delete("api/Home/DeleteUser/" + id).subscribe(result =>{
      console.log("delete user");
      console.log(result);
      this.GetAllUsers();
    }, error => console.error(error));
  }
}

