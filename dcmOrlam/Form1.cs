using System;
using System.Windows.Forms;
using EvilDICOM.Core;
using EvilDICOM.Core.Element;
using EvilDICOM.Core.Selection;
using EvilDICOM.Core.Helpers;
using System.IO;


namespace dcmOrlam
{
	public partial class Form1 : Form
	{
		TextWriter _writer = null;
		bool test = true;

		public Form1()
		{
			InitializeComponent();
		}

		private void button_VMAT_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			//	DialogResult dr = this.openFileDialog1.ShowDialog();
			openFileDialog1.Multiselect = true;
			openFileDialog1.InitialDirectory = "\\\vaimg101.vaonc-vil.local\\DICOM\\RS2VARIAN\\Import";

			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				foreach (String file in openFileDialog1.FileNames)
				{
					string sourceFile = file;
					string NomFchier = openFileDialog1.SafeFileName;
					Console.WriteLine("Fichier : '"+ NomFchier+"' ");
					textBox_result.Text = sourceFile;
					vidangeligne(sourceFile);
					calculprescription(sourceFile);
					Console.WriteLine(" ");
					
					if (test==true)
					{
						status.ForeColor = System.Drawing.Color.Black;
						status.Text = "";
						status.Text = "Le fichier " + NomFchier + "a été modifié";
					}
					test = true;
				};
			}
		}
				
		private void button_AutoBreast_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			//	DialogResult dr = this.openFileDialog1.ShowDialog();
			openFileDialog1.Multiselect = true;
			openFileDialog1.InitialDirectory = "\\\vaimg101.vaonc-vil.local\\DICOM\\RS2VARIAN\\Import";


			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				foreach (String file in openFileDialog1.FileNames)
				{
					Console.WriteLine("Fichier : " + file);
					string sourceFile = file;
					string NomFchier = openFileDialog1.SafeFileName;
					textBox_result.Text = sourceFile;
					vidangeligne(sourceFile);
					calculprescription(sourceFile);
					ajouttag(sourceFile);
					
					if (test == true)
					{
						status.ForeColor = System.Drawing.Color.Black;
						status.Text = "";
						status.Text = "Le fichier '" + NomFchier + "'a été modifié";
					}
					test = true;
				};
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			_writer = new TextBoxStreamWriter(textConsole);
			Console.SetOut(_writer);
		}

		private void vidangeligne(String nom)
		{
			var dcm = DICOMObject.Read(nom);
			var sel = new DICOMSelector(dcm);

			try
			{
				var Vertical = sel.TableTopVerticalPosition_;
				var Longitudinal = sel.TableTopLongitudinalPosition_;
				var Lateral = sel.TableTopLateralPosition_;

				for (int i = 0; i < Vertical.Count; i++)
				{
					sel.TableTopVerticalPosition_[i].Data_.Clear();
				}

				for (int j = 0; j < Longitudinal.Count; j++)
				{
					sel.TableTopLongitudinalPosition_[j].Data_.Clear();
				}

				for (int k = 0; k < Lateral.Count; k++)
				{
					sel.TableTopLateralPosition_[k].Data_.Clear();
				}
				Console.WriteLine("- Les lignes 'Table TopVertical Position', 'Table Top Longitudinal Position' et 'TableTopLateralPosition' sont vide.");
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("Impossible de vider les lignes pour le fichier " + nom, "Erreur", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
				status.ForeColor = System.Drawing.Color.Red;
				status.Text = "Modification interrompu ";
				test = false;
			}
			dcm.Write(nom);
		}
		private void calculprescription(String nom)
		{
			var dcm = DICOMObject.Read(nom);
			var sel = new DICOMSelector(dcm);

			try
			{
				var PrescripDose = sel.TargetPrescriptionDose.Data;
				var DoseFraction = sel.NumberOfFractionsPlanned.Data;

				var DoseParSeance = PrescripDose / DoseFraction;

				Console.WriteLine("- Prescription Dose : " + PrescripDose);
				Console.WriteLine("- Dose par Seance :  " + DoseFraction);
				Console.WriteLine("- Fraction de la dose : " + DoseParSeance);

				var BeamDoseSpec = sel.BeamDoseSpecificationPoint_;

				// nombre de dose 
				var NbBeamDoseSpec = sel.BeamDoseSpecificationPoint_.Count;
				//var NbBeamDoseSpec = 3;

				for (int i = 0; i < BeamDoseSpec.Count; i++)
				{
					sel.BeamDoseSpecificationPoint_[i].Data_.Clear();
				}
				Console.WriteLine("- Les " + sel.BeamDoseSpecificationPoint_.Count + " champs 'Beam Dose Spécifation Point' sont maintenant vides ");

				var numberDose_nar = DoseParSeance / NbBeamDoseSpec;
				var numberDose = Math.Round(numberDose_nar, 3);

				Console.WriteLine("Nombre de dose: " + numberDose);

				var beamdose = sel.BeamDose_;
				var nbBeamDose = beamdose.Count-1;
				for (int i = 0; i < beamdose.Count; i++)
				{
					for (int k = 0; i < beamdose.Count; i++)
					{
						sel.BeamDose_[i].Data_[k] = numberDose;

						if (nbBeamDose == i)
						{
							var total = numberDose * nbBeamDose;
							var totallast = DoseParSeance - total;
							sel.BeamDose_[i].Data_[k] = totallast;
						}
						Console.WriteLine("Faisceau " + i +" : "+ sel.BeamDose_[i].Data_[k]);
					}
				}
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("Impossible de calculer la dose pour le fichier "+ nom, "Erreur",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
				status.ForeColor = System.Drawing.Color.Red;
				status.Text = "Modification interrompu";
				test = false;
			};
			dcm.Write(nom);
		}
		private void ajouttag(String nom )
		{
			var dcm = DICOMObject.Read(nom);
			var sel = new DICOMSelector(dcm);

			var refDoseRate = new DecimalString
			{
				Tag = TagHelper.DoseRateSet,
				Data = 400
			};

			var nbBeams = sel.NumberOfBeams.Data;

			for (int i = 0; i < nbBeams; i++)
			{
				sel.ControlPointSequence_[i].Items[0].Add(refDoseRate);
			}
			Console.WriteLine("- Ajout du tag pour l'AutoBreast");
			dcm.Write(nom);
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
