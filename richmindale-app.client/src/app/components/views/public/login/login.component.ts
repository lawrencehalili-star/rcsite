import { Component } from '@angular/core';
import { AuthService } from '../../../../shared/services/auth/auth.service';
import { ToastrService } from 'ngx-toastr';
import { StorageService } from '../../../../shared/services/auth/storage.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
 
  isOTP:boolean = false;
  username:any;
  passkey:any;
  constructor(private service: AuthService, private router: Router, private route: ActivatedRoute, private storage: StorageService, private toastr: ToastrService) {}

  VerifyEmail(event:any) : void {
    event.target.disabled = true;
    this.service.authenticateStudent(this.username).subscribe(res => {
      if(res.status === 'success') {
        this.isOTP = true;
      } else {
        event.target.disabled = false;
        this.toastr.error(res.msg);
      }
    });
    
  }

  ValidatePasskey() : void {
    let returnUrl = this.route.snapshot.queryParamMap.get('returlUrl') || '/rims/dashboard';
    this.service.validatePasskey(this.username, this.passkey).subscribe(res => {
      if(res.status === 'success') {
        if(res.info.Id !== '00000000-0000-0000-0000-000000000000') {
          this.storage.saveSession("UserId", res.info.Id);
          this.storage.saveSession("StudentId", res.info.StudentId);
          this.storage.saveSession("IsAdmin", "0");
          this.storage.saveSession("IsLoggedIn", "1");
          this.storage.saveSession("DisplayName", res.info.DisplayName);
          this.storage.saveSession("RoleId", res.info.RoleId);
          this.storage.saveSession("RoleName", res.info.RoleName);
          this.toastr.success(res.msg);
          this.router.navigateByUrl(returnUrl);
        } else {
          this.toastr.error("Invalid credentials");
        }
      } else {
        this.storage.saveSession("IsLoggedIn", "0");
        this.toastr.error(res.msg);
      }
    });
  }

  CancelLogin() : void {
    window.location.href = '/home';
  }

}
