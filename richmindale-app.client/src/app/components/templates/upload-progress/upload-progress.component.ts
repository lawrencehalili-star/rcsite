import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-upload-progress',
  templateUrl: './upload-progress.component.html'
})
export class UploadProgressComponent implements OnInit {

  @Input() progress = 0;
  constructor() {}
  ngOnInit(): void {
    
  }


}
