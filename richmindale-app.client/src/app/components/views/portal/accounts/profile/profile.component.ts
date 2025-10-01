import { Component, ComponentFactoryResolver, OnInit } from '@angular/core';
import { Profile } from '../../../../../shared/models/portal/profile.model';
import { CommonService } from '../../../../../shared/services/common.service';
import { ProfileService } from '../../../../../shared/services/portal/profile.service';
import { ToastrService } from 'ngx-toastr';
import { StorageService } from '../../../../../shared/services/auth/storage.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html'
})
export class ProfileComponent implements OnInit {

  id: any;
  nationalities:any[] = [];
  marital:any[] = [];
  prof: Profile = new Profile();
  updatePass:boolean = false;

  constructor(private storage: StorageService,  private common: CommonService, private service: ProfileService, private toastr: ToastrService ) {}

  ngOnInit(): void {
    this.id = this.storage.getSession("UserId");
    console.log('UserId: ' + this.id);
    this.service.getStudentProfile(this.id).subscribe(res => { this.prof = res;});
    this.common.getNationality().subscribe(res => { this.nationalities = res; });
    this.common.getMaritalStatus().subscribe(res => { this.marital = res; });
  }

  UpdatePass() : void {
    this.updatePass = !this.updatePass;
  }

  SavePass() : void {
    if(this.prof.NewPassword !== this.prof.ConfirmPassword) {
      this.toastr.error('Password mismatch!');
    } else {
      this.service.updatePassword(this.id, this.prof.NewPassword).subscribe(res => {
        if(res.status === 'success') {
          this.toastr.success(res.msg);
        } else {
          this.toastr.error(res.msg);
        }
      });
      this.updatePass = !this.updatePass;
    }
  }

  CancelUpdatePass() : void {
    this.updatePass = !this.updatePass;
  }



  
}
