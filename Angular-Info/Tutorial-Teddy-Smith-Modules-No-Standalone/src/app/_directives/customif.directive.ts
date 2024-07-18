import {
  Directive,
  Input,
  OnInit,
  TemplateRef,
  ViewContainerRef,
} from '@angular/core';

@Directive({
  selector: '[customif]',
})
export class CustomifDirective implements OnInit {
  @Input() customif: boolean = false;
  constructor(
    private templateRef: TemplateRef<any>,
    private viewcontainer: ViewContainerRef
  ) {}

  ngOnInit(): void {
    if (this.customif) {
      this.viewcontainer.createEmbeddedView(this.templateRef);
    } else {
      this.viewcontainer.clear();
    }
  }
}
