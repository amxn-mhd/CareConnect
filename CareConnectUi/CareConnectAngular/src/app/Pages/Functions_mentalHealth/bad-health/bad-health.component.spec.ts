import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BadHealthComponent } from './bad-health.component';

describe('BadHealthComponent', () => {
  let component: BadHealthComponent;
  let fixture: ComponentFixture<BadHealthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BadHealthComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BadHealthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
