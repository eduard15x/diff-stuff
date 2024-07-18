import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[highlighttext]',
})
export class HighlighttextDirective {
  constructor(private el: ElementRef) {}

  @HostListener('mouseenter') onMouseEnter() {
    this.el.nativeElement.style.backgroundColor = 'red';
    this.el.nativeElement.style.color = 'black';
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.el.nativeElement.style.backgroundColor = 'black';
    this.el.nativeElement.style.color = 'white';
  }
}
