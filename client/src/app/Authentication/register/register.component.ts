import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationClient } from '../clients/authentication.client';
import { AuthenticationService } from '../services/authentication.service';
import { RegisterUser } from './registerUser.dto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {

  }

  onClickSubmit(data:any) {
     this.authenticationService.register(
      data.username,
      data.firstName,
      data.lastName,
      data.password
     )

  }
  }


