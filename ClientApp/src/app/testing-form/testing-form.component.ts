import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-testing-form',
  templateUrl: './testing-form.component.html',
  styleUrls: ['./testing-form.component.css']
})
export class TestingFormComponent implements OnInit {
  user = {first_name:"", last_name:"",email:"",password:"",confirm_password:""}
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  CreateUser(){
    console.log(this.user); 
    console.log("line 16 in testing form ts user created" + this.user);
    this.http.post("api/Home/createUser",this.user).subscribe(result => {
      console.log("line 18 in testing form ts getting all users");
      console.log(result);
      this.user = {first_name:"", last_name:"",email:"",password:"",confirm_password:""};
    }, error => console.error(error));
  }
}
