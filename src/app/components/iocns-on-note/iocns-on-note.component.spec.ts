import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IocnsOnNoteComponent } from './iocns-on-note.component';

describe('IocnsOnNoteComponent', () => {
  let component: IocnsOnNoteComponent;
  let fixture: ComponentFixture<IocnsOnNoteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IocnsOnNoteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IocnsOnNoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
