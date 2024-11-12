import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScoremeterComponent } from './scoremeter.component';

describe('ScoremeterComponent', () => {
  let component: ScoremeterComponent;
  let fixture: ComponentFixture<ScoremeterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ScoremeterComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScoremeterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
