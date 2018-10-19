import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'; // communicate with client side
@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  public userId;
  public currentUser;
  public update={first_name:"",last_name:"",email:""};
  constructor(private http: HttpClient,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit() {
    this._route.params.subscribe((params: Params) => {
      this.userId = params.id;
      console.log(this.userId);
      this.GetOneUser();
    });
  }
  GetOneUser(){
    this.http.get("api/Home/GetOne/" + this.userId).subscribe(result=>{
      console.log("get one User");
      console.log(result);
      this.currentUser = result;
      this.update ={first_name:result['first_name'], last_name:result['last_name'],email:result['email']};
    }
    )
  }
  UpdateUser(id){
    console.log("========");
    console.log(id);
    console.log(this.update);
    console.log("=======");
    this.http.patch("api/Home/updateUser/" + id,this.update).subscribe(result=>{
      console.log("Update User");
      console.log(result);
      this.update = {first_name:"",last_name:"",email:""};
      this._router.navigate(['/fetch-data']);
    })
  }

}
