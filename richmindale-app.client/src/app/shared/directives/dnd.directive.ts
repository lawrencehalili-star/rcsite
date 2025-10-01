import { Directive, Output, Input, EventEmitter, HostBinding, HostListener } from '@angular/core';

@Directive({
  selector: '[appDnd]'
})
export class DndDirective {

  @HostBinding('class.fileOver') fileOver?: boolean;
  @Output() fileDropped = new EventEmitter<any>;

  // Dragover Listener
  @HostListener('dragover', ['$event']) onDragOver(evt:any) {
    evt.preventDefault();
    evt.stopPropagation();
    this.fileOver = true;
  }

  // Dragleave Listener
  @HostListener('dragleave', ['$event']) onDragLeave(evt:any) {
    evt.preventDefault();
    evt.stopPropagation();
    this.fileOver = false;
  }

  @HostListener('drop', ['$event']) onDrop(evt:any) {
    evt.preventDefault();
    evt.stopPropagation();
    this.fileOver = false;
    let files = evt.dataTransfer.files;
    if(files.length > 0) {
      this.fileDropped.emit(files);
    }
  }

}
